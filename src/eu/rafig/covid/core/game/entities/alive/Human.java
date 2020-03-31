package eu.rafig.covid.core.game.entities.alive;

import eu.rafig.covid.core.game.common.Randomizer;
import eu.rafig.covid.core.game.entities.alive.organs.Lungs;
import eu.rafig.covid.core.game.entities.alive.organs.Organ;
import eu.rafig.covid.core.game.entities.alive.organs.OrganState;
import eu.rafig.covid.core.game.entities.placeable.Imunity;
import eu.rafig.covid.core.game.entities.placeable.Virus;
import eu.rafig.covid.core.game.entities.specs.Health;
import eu.rafig.covid.core.game.entities.specs.Infection;
import eu.rafig.covid.core.game.entities.specs.Vitals;

import java.util.ArrayList;
import java.util.List;

public class Human implements Alive {
    private State humanState = State.ALIVE;
    private Vitals humanVitals = new Vitals();
    private List<Organ> organs = new ArrayList<>();

    public Human() {
        organs.add(new Lungs());
    }

    public void goToBed() {
        if (humanState != State.ILL) {
            //FIXME: fix it now it looks like shit
            if (Randomizer.getRandomNumberMax(6) ==1 ) {
                organs.get(0).addToOrgan(new Virus());
                organs.get(0).addToOrgan(new Imunity());
                humanState = State.ILL;
            }
        }
        double healthValue = 1;
        boolean destroyed = true;
        boolean cured = true;

        for ( Organ organ: organs) {
            healthValue *= organ.helthCheck();
            organ.iterateOrgan();

            if (organ.getOrganState() != OrganState.DESTROYED) destroyed = false;
            if (organ.getOrganState() != OrganState.CURED) cured = false;
        }

        humanVitals.getHealth().applyChanges(healthValue);

        if (destroyed || getVitals().getHealth().getCurrentHealth() <= 0 ) humanState = State.DEAD;
        if (cured ) humanState = State.CURED;

    }

    @Override
    public State getState() {
        return humanState;
    }

    @Override
    public Health getLife() {
        return humanVitals.getHealth();
    }

    @Override
    public Infection getInfectionSpread() {
        return humanVitals.getInfection();
    }

    @Override
    public Vitals getVitals() {
        return humanVitals;
    }

    @Override
    public List<Organ> getHumanOrgans() {
        return organs;
    }
}
