package eu.rafig.covid.core.game.entities.specs;

import eu.rafig.covid.core.game.common.Constants;

public class Health {
    private double currentHealth = Constants.MAX_HEALTH;

    public Health(double currentHealth) {
        this.currentHealth = currentHealth;
    }

    public Health(){

    }

    public void applyChanges(double value){
        if (value == 0) return;
        currentHealth += value/Constants.HEALTH_DIVIDE_CONSTANT;
        if (currentHealth >= Constants.MAX_HEALTH) currentHealth = Constants.MAX_HEALTH;
        if (currentHealth <= 0) currentHealth = 0;
    }

    public double getCurrentHealth() {
        return currentHealth;
    }
}
