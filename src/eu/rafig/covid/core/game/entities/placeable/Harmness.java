package eu.rafig.covid.core.game.entities.placeable;

public enum Harmness {
    NEGATIVE(0), POSITIVE(1), NEUTRAL(-1);

    private int harmness;

    Harmness(int effect) {
        harmness = effect;
    }

    public int getHarmness() {
        return harmness;
    }
}
