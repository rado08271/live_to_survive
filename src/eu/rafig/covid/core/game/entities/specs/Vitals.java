package eu.rafig.covid.core.game.entities.specs;

public class Vitals {
    private Health health ;
    private Money money;

    public Vitals() {
        health = new Health();
        money = new Money(0);
    }

    public Health getHealth() {
        return health;
    }

    public Money getMoney() {
        return money;
    }
}
