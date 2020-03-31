package eu.rafig.covid.core.game.entities.specs;

public class Infection {
    private double currectInfectionValue = 0;

    public Infection(){

    }

    public void applyChanges(double value){
        if (value == 0) return;
        currectInfectionValue *= value;
    }

    public double getCurrectInfectionValue() {
        return currectInfectionValue;
    }
}
