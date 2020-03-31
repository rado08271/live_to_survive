package eu.rafig.covid.core.game.entities.specs;

public class Vitals {
    private Health health = new Health();
    private Infection infection = new Infection();

    public Vitals() {
    }

    public Health getHealth() {
        return health;
    }

    public Infection getInfection() {
        return infection;
    }
}
