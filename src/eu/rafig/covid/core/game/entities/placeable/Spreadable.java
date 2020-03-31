package eu.rafig.covid.core.game.entities.placeable;

import java.util.List;

public interface Spreadable<T> {
    List<T> getRandomKids(int max);
}
