package eu.rafig.covid.core.game.entities.alive;

import eu.rafig.covid.core.game.entities.alive.organs.Organ;
import eu.rafig.covid.core.game.entities.specs.Health;
import eu.rafig.covid.core.game.entities.specs.Infection;
import eu.rafig.covid.core.game.entities.specs.Vitals;

import java.util.List;

public interface Alive {
    State getState();
    Health getLife();
    Infection getInfectionSpread();
    Vitals getVitals();
    List<Organ> getHumanOrgans();
}
