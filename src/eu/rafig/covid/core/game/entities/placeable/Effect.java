package eu.rafig.covid.core.game.entities.placeable;

public enum Effect {
    NEUTRAL(0), POSITIVE(-1), NEGATIVE(1);

    private int multiplier;
    Effect(int multiplier) {
        this.multiplier = multiplier;
    }

    public int getMultiplier() {
        return multiplier;
    }
}
