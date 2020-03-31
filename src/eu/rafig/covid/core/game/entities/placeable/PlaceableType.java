package eu.rafig.covid.core.game.entities.placeable;

public enum PlaceableType {
    CELL(Effect.NEUTRAL), DNA(Effect.NEUTRAL), RNA(Effect.NEUTRAL), IMUNITY(Effect.POSITIVE, 1.1), VIRUS(Effect.NEGATIVE, 1.3);

    private Effect effect;
    private double effectConstant = 0;

    PlaceableType(Effect effect, double effectConstant) {
        this.effect = effect;
        this.effectConstant = effectConstant;
    }

    PlaceableType(Effect effect) {
        this.effect = effect;
    }

    public double getEffectByValue() {
        return effect.getMultiplier() * effectConstant;
    }

    public Effect getEffect() {
        return effect;
    }
}
