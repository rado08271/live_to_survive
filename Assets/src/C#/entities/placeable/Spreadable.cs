using System.Collections;
using System.Collections.Generic;

namespace eu.parada.entities.placeable {
    public interface Spreadable<T> {
        IList<T> getRandomKids(int max);
        double getHarmnessLevel();

    }
}
