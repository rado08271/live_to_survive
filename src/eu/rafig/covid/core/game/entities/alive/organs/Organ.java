package eu.rafig.covid.core.game.entities.alive.organs;

import eu.rafig.covid.core.game.entities.effects.GameEffects;
import eu.rafig.covid.core.game.entities.placeable.*;
import eu.rafig.covid.core.game.entities.specs.Vitals;

import java.lang.management.PlatformLoggingMXBean;
import java.util.*;

public abstract class Organ {
    protected Vitals vitals;
    protected String desctiption;
    protected Map<PlaceableType, List<Placeable>> everythingInside;
    protected OrganState organState = OrganState.WORKING;

    public Organ(int availableCells, String desctiption) {
        initMap();

        // TODO: create class for this...
        for (int i = 0; i < availableCells; i++) {
            addToOrgan(new Cell());
        }

        this.desctiption = desctiption;
        vitals = new Vitals();
    }

    private void initMap() {
        this.everythingInside = new HashMap<>();

        everythingInside.put(PlaceableType.CELL, new ArrayList<>());
        everythingInside.put(PlaceableType.DNA, new ArrayList<>());
        everythingInside.put(PlaceableType.IMUNITY, new ArrayList<>());
        everythingInside.put(PlaceableType.RNA, new ArrayList<>());
        everythingInside.put(PlaceableType.VIRUS, new ArrayList<>());
    }

    public boolean addToOrgan(Placeable placeable) {
        if (getAllPlaceable(placeable.getType()).size() >= getAllPlaceable(PlaceableType.CELL).size()) {
            if (placeable.getType() == PlaceableType.VIRUS) {
                organState = OrganState.DESTROYED;
                return false;
            } else if (placeable.getType() == PlaceableType.IMUNITY) {
                // FIXME: this might not happen at all...and probably will not so rather do it by checking effects
                organState = OrganState.CURED;
                return false;
            }
        }

        everythingInside.get(placeable.getType()).add(placeable);
        return true;
    }

    public void addListToOrgan(List<Placeable> placeableList) {
        for (Placeable placeable: placeableList) {
            addToOrgan(placeable);
        }
    }

    public void removeFromOrgan(Placeable placeable) {
        everythingInside.get(placeable.getType()).remove(placeable);
    }

    public void removeListFromOrgan(List<Placeable> placeableList) {
        for (Placeable placeable: placeableList) {
            removeFromOrgan(placeable);
        }
    }


    public List<Placeable> getAllPlaceable(PlaceableType type) {
        return everythingInside.get(type);
    }

    public void reproduction() {
        //TODO: First viruses will cause harm
        //FIXME: This is just quickfix = ojebovak

        List<Placeable> placeableViruses = new ArrayList<>();
        for (Placeable p : getAllPlaceable(PlaceableType.VIRUS)) {
            if (p instanceof Virus) {
                placeableViruses.addAll(((Virus) p).getRandomKids(GameEffects.getBonus()));
            }
        }
        addListToOrgan(placeableViruses);

        List<Placeable> placeableImunities = new ArrayList<>();
        for (Placeable p : getAllPlaceable(PlaceableType.IMUNITY)) {
            if (p instanceof Imunity) {
                placeableImunities.addAll(((Imunity) p).getRandomKids(GameEffects.getBonus()));
            }
        }
        addListToOrgan(placeableImunities);

    }

    private List<Placeable> getSpecificAmmount(PlaceableType type, int ammount) {
        if (getAllPlaceable(type).size() >= ammount) ammount = getAllPlaceable(type).size();
        return getAllPlaceable(type).subList(0, ammount);
    }

    public void fight() {
        int viruses = getAllPlaceable(PlaceableType.VIRUS).size();
        int imunities = getAllPlaceable(PlaceableType.IMUNITY).size();

        if ( viruses > imunities) {
            viruses = viruses - imunities;
            imunities = 0;
            if (viruses < 0) viruses = 0;
        } else {
            imunities = imunities - viruses;
            viruses = 0;
            if (imunities < 0) imunities = 0;
        }

        List<Placeable> placeableViruses = new ArrayList<>();
        for (int i = 0; i < getAllPlaceable(PlaceableType.VIRUS).size() - viruses; i++) {
            placeableViruses.add(getAllPlaceable(PlaceableType.VIRUS).get(i));
        }

        List<Placeable> placeableImunities = new ArrayList<>();
        for (int i = 0; i < getAllPlaceable(PlaceableType.IMUNITY).size() - imunities; i++) {
            placeableImunities.add(getAllPlaceable(PlaceableType.IMUNITY).get(i));
        }

        removeListFromOrgan(placeableViruses);
        removeListFromOrgan(placeableImunities);
    }

    public double helthCheck() {
        double value = 1;
        for (PlaceableType type: everythingInside.keySet()) {
            for (Placeable p: getAllPlaceable(type)) {
                if (p.getEffect() != Effect.NEUTRAL)
                    value *= p.getType().getEffectByValue();
            }
        }

        vitals.getHealth().applyChanges(value);
        return value;
    }

    public String getStats() {
        return ("\nCELL: " + getAllPlaceable(PlaceableType.CELL).size() +
                "\nDNA: " + getAllPlaceable(PlaceableType.DNA).size() +
                "\nIMUNITY: " + getAllPlaceable(PlaceableType.IMUNITY).size() +
                "\nRNA: " + getAllPlaceable(PlaceableType.RNA).size() +
                "\nVIRUS: " + getAllPlaceable(PlaceableType.VIRUS).size());
    }

    public void iterateOrgan() {
        reproduction();
        fight();
    }

    public Vitals getVitals() {
        return vitals;
    }

    public String getDesctiption() {
        return desctiption;
    }

    public OrganState getOrganState() {
        return organState;
    }
}
