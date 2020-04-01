package eu.rafig.covid.core.game.entities.alive.organs;

import eu.rafig.covid.core.game.common.ListFiller;
import eu.rafig.covid.core.game.entities.effects.Effect;
import eu.rafig.covid.core.game.entities.effects.GameEffects;
import eu.rafig.covid.core.game.entities.placeable.*;
import eu.rafig.covid.core.game.entities.specs.Vitals;

import java.util.*;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class Lungs {
    private Vitals vitals;
    private String desctiption;
    private LungsState lungsState = LungsState.WORKING;
    private int dayTime = 0;

    private List<Virus> viruses;
    private List<Imunity> imunities;
    private List<Cell> cells;
    private List<Effect> boughtEffects;

    public Lungs(int availableCells, String desctiption) {
        this.desctiption = desctiption;
        vitals = new Vitals();

        viruses = new ListFiller<Virus>().fillList(new Virus(), 0);
        imunities = new ListFiller<Imunity>().fillList(new Imunity(), 0);
        cells = new ListFiller<Cell>().fillList(new Cell(), availableCells);
        boughtEffects = new ArrayList<>();
    }

    private void hardLaborForImmunity() {
        vitals.getMoney().earnMoney(imunities.size()/2);
    }

    private void reproduction() {
        List<Virus> virs = new ArrayList<>();
        for (Virus v: viruses) {
            virs.addAll(v.getRandomKids(boughtEffects.size()));
        }

        if ( getViruses().size()  + virs.size() > getCells().size()) {
            virs = new ListFiller<Virus>().fillList(virs.get(0), cells.size());
            lungsState = LungsState.DESTROYED;
        }

        getViruses().addAll(virs);

        List<Imunity> imms = new ArrayList<>();
        for (Imunity v: imunities) {
            imms.addAll(v.getRandomKids(boughtEffects.size()));
        }

        if ( getImunities().size() + imms.size() > getCells().size()) {
            imms = new ListFiller<Imunity>().fillList(imms.get(0), cells.size());
            lungsState = LungsState.CURED;
        }

        getImunities().addAll(imms);

        // earn some small amount of money by reproduction
        vitals.getMoney().earnMoney((virs.size() + imms.size())/4);
    }

    public boolean fight() {
        if (dayTime == 3) return false;

        int viruses = getViruses().size();
        int imunities = getImunities().size();

        if ( viruses > imunities) {
            viruses = viruses - imunities;
            imunities = 0;
            if (viruses < 0) viruses = 0;
        } else {
            imunities = imunities - viruses;
            viruses = 0;
            if (imunities < 0) imunities = 0;
        }

        int virusesSize = getViruses().size();
        for (int i =  virusesSize - viruses -1; i >= 0; i--) {
            getViruses().remove(i);
        }

        int immunitiesSize = getImunities().size();
        for (int i = immunitiesSize - imunities -1; i >= 0; i--) {
            getImunities().remove(i);
        }

        getVitals().getMoney().earnMoney(immunitiesSize - getImunities().size());

        dayTime++;
        return true;
    }

    private double healthCheck() {
        double value = 0;
        for (Spreadable v: getSpreadable()) {
            value += v.getHarmnessLevel();
        }

        if (getViruses().size() == 0 && lungsState == LungsState.INFECTED) {
            lungsState = LungsState.CURED;
        }
        vitals.getHealth().applyChanges(value);
        return value;
    }

    private List<Spreadable> getSpecificAmmount(List<Spreadable> spreadables, int ammount) {
        if (spreadables.size() >= ammount) ammount = spreadables.size();
        return spreadables.subList(0, ammount);
    }

    public boolean buyEffect(Effect effect) {
        if (!vitals.getMoney().butStuff(effect.getDnaPrice())) return false;
        if (effect.isActive()) return false;
        if (boughtEffects.contains(effect)) return false;

        boughtEffects.add(effect);
        effect.setActive(true);

        return true;
    }

    public boolean addVirus() {
        if (lungsState == LungsState.INFECTED) return false;
        viruses.add(new Virus());

        lungsState = LungsState.INFECTED;
        return true;
    }

    public boolean addImmunities(List<Imunity> imunities) {
        if (getImunities().size() + imunities.size() > getCells().size()) return false;
        if (!vitals.getMoney().butStuff(imunities.size())) return false;

        getImunities().addAll(imunities);
        return true;
    }

    public void endDay() {
        dayTime = 0;
        hardLaborForImmunity();
        healthCheck();
        reproduction();
    }

    public Vitals getVitals() {
        return vitals;
    }

    public String getDesctiption() {
        return desctiption;
    }

    public LungsState getLungsState() {
        return lungsState;
    }

    public List<Spreadable> getSpreadable() {
        List<Spreadable> spreadables = new ArrayList<Spreadable>(getViruses());
        spreadables.addAll(getImunities());
        return spreadables;
    }

    public List<Virus> getViruses() {
        return viruses;
    }

    public List<Imunity> getImunities() {
        return imunities;
    }

    public List<Cell> getCells() {
        return cells;
    }

    public List<Effect> getBoughtEffects() {
        return boughtEffects;
    }

    public String getDayTime() {
        if (dayTime == 0) return "Morning";
        else if (dayTime == 1) return "Noon";
        else if (dayTime == 2) return "Night";
        else return "Sleeping";
    }
}
