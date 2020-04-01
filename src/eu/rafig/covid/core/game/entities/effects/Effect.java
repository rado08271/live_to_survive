package eu.rafig.covid.core.game.entities.effects;

//TODO: if effects are more complex then redefine each effect
public class Effect {
    private String desciption;
    private boolean isActive;
    private double dnaPrice;

    public Effect(String desciption, double dnaPrice) {
        this.desciption = desciption;
        this.isActive = false;
        this.dnaPrice = dnaPrice;
    }

    public String getDesciption() {
        return desciption;
    }

    public double getDnaPrice() {
        return dnaPrice;
    }

    public boolean isActive() {
        return isActive;
    }

    public void setActive(boolean active) {
        isActive = active;
    }
}
