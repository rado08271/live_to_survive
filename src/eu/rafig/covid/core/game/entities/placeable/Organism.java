package eu.rafig.covid.core.game.entities.placeable;

public abstract class Organism {
    private double constant = 0;
    private String name = "";
    private Harmness harmness = Harmness.NEUTRAL;

    public Organism(double constant, Harmness harmness) {
        this.constant = constant;
        this.harmness = harmness;
    }

    public Organism(double constant, String name) {
        this.constant = constant;
        this.name = name;
    }

    public Organism(double constant) {
        this.constant = constant;
    }

    public double getConstant() {
        return constant;
    }

    public String getName() {
        return name;
    }

    public Harmness getHarmness() {
        return harmness;
    }
}
