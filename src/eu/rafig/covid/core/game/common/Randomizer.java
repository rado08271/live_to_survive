package eu.rafig.covid.core.game.common;

import java.util.Random;

public class Randomizer {

    public static int getRandomNumber(int min, int max) {
        return new Random().nextInt((max - min) + 1) + min;
    }

    public static int getRandomNumberMax(int max) {
        return getRandomNumber(0, max);
    }
}
