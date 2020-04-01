package eu.rafig.covid.core.game.entities.specs;

import eu.rafig.covid.core.game.common.Constants;

public class Vitals {
    private Health health ;
    private Money money;

    public Vitals() {
        health = new Health();
        money = new Money(Constants.STARTIN_MONEY);
    }

    public Health getHealth() {
        return health;
    }

    public Money getMoney() {
        return money;
    }
}
