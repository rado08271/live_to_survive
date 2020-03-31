package eu.rafig.covid.core.game.time;

import eu.rafig.covid.core.game.common.DayCounter;

public class Day {
    private DayStatus dayStatus = DayStatus.TOBE;
    private int dayNumber;

    public Day() {
        this.dayNumber = DayCounter.increaseDay();
    }

    private void setCurrent() {
        dayStatus = DayStatus.CURRENT;
    }

    private void hasPassed() {
        dayStatus = DayStatus.PASSED;
    }

    public DayStatus dayStatus(int currentDay) {
        if (currentDay == dayNumber) {
            setCurrent();
        } else if (currentDay > dayNumber) {
            hasPassed();
        }

        return dayStatus;
    }

    public int getDayNumber() {
        return dayNumber;
    }
}
