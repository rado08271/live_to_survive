package eu.rafig.covid.core.game.entities.specs;

import eu.rafig.covid.core.game.common.Constants;

public class Energy {
    private double currentEnergy = Constants.MAX_HEALTH;

    public Energy() {
    }

    public Energy(double currentEnergy) {
        this.currentEnergy = currentEnergy;
    }

    public double getEnergy() {
        return currentEnergy;
    }

    public boolean decreaseEnergy(double value) {
        if (currentEnergy - value < 0 ) {
            currentEnergy = 0;
            return false;
        }
        currentEnergy -= value;
        return true;
    }

    public boolean increaseEnergy(double value ) {
        if (value + currentEnergy > Constants.MAX_HEALTH) {
            currentEnergy = Constants.MAX_HEALTH;
            return false;
        }
        currentEnergy += value;
        return true;
    }
}
