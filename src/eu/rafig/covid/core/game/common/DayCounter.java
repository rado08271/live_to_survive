package eu.rafig.covid.core.game.common;

public class DayCounter {
    private static int dayCount = 0;

    public static int increaseDay() {
        return dayCount++;
    }

    public static int getDayCount() {
        return dayCount;
    }
}
