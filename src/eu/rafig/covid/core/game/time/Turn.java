package eu.rafig.covid.core.game.time;

import java.util.ArrayList;
import java.util.List;

public class Turn {
    private List<Day> days;
    private int currentTurn = 0;

    public Turn(int turns) {
        days = new ArrayList<>();

        for (int i = 0; i <= turns; i++) {
            days.add(new Day());
        }
    }

    public boolean skipTurn() {
        currentTurn++;
        days.forEach(day -> day.dayStatus(currentTurn));
        if ( currentTurn == 14) {
            System.out.println("wow");
        }
        return currentTurn < days.size();
    }

    public Day getCurrentDay() {
        if ( currentTurn >= days.size()-1)
            return days.get(days.size()-1);
        return days.get(currentTurn);
    }

    public List<Day> getPreviousDays() {
        return days.subList(0, currentTurn-1);
    }

}
