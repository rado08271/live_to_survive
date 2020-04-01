package eu.rafig.covid.core.game.entities.effects;

import eu.rafig.covid.core.game.common.ListFiller;
import eu.rafig.covid.core.game.entities.alive.organs.Lungs;
import eu.rafig.covid.core.game.entities.placeable.Imunity;

import java.util.List;

public class Event {
    private Lungs lungs;

    public Event(Lungs lungs) {
        this.lungs = lungs;
    }

    public void addVirus() {
        lungs.addVirus();
    }

    public boolean buyImmunity(int count) {
        List<Imunity> imunitiesToBuy = new ListFiller<Imunity>().fillList(new Imunity(), count);
        return lungs.addImmunities(imunitiesToBuy);
    }
}
