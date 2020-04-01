package eu.rafig.covid.core.game.entities.specs;

public class Health {
    private double currentHealth = 100;

    public Health(){

    }

    public void applyChanges(double value){
        if (value == 0) return;
        currentHealth += value/10;
    }

    public double getCurrentHealth() {
        return currentHealth;
    }
}
