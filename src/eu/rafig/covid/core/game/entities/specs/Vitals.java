package eu.rafig.covid.core.game.entities.specs;

import com.sun.xml.internal.bind.v2.runtime.reflect.opt.Const;
import eu.rafig.covid.core.game.common.Constants;

public class Vitals {
    private Health health ;
    private Energy energy;
    private Money money;

    public Vitals() {
        health = new Health(Constants.STARTING_HEALTH);
        money = new Money(Constants.STARTING_MONEY);
        energy = new Energy(Constants.STARTING_ENERGY);
    }

    public Health getHealth() {
        return health;
    }

    public Money getMoney() {
        return money;
    }

    public Energy getEnergy() {
        return energy;
    }
}
