package eu.rafig.covid.core.game.common;

import java.util.ArrayList;
import java.util.List;

public class ListFiller<T> {


    public List<T> fillList(T typeOfObject, int size) {
        List<T> listToFill = new ArrayList<>();

        for (int i = 0; i < size; i++) {
            listToFill.add(typeOfObject);
        }

        return listToFill;
    }
}
