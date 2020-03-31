package eu.rafig.covid.core.game.entities.placeable;

public abstract class Organism implements Placeable {
    private PlaceableType type;

    public Organism(PlaceableType type) {
        this.type = type;
    }

    @Override
    public PlaceableType getType() {
        return type;
    }

    @Override
    public Effect getEffect() {
        return type.getEffect();
    }
}
