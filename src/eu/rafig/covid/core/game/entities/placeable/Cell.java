package eu.rafig.covid.core.game.entities.placeable;

import eu.rafig.covid.core.game.common.Constants;

public class Cell extends Organism {

    public Cell() {
        super(Constants.HARMNESS_FOR_CELL, Harmness.NEUTRAL);
    }
}
