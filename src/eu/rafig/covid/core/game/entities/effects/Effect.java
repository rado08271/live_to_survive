package eu.rafig.covid.core.game.entities.effects;

//TODO: if effects are more complex then redefine each effect
public class Effect {
    private String desciption;
    private boolean isActive;
    private int dnaPrice;

    public Effect(String desciption, int dnaPrice) {
        this.desciption = desciption;
        this.isActive = false;
        this.dnaPrice = dnaPrice;
    }

    public String getDesciption() {
        return desciption;
    }

    public int getDnaPrice() {
        return dnaPrice;
    }

    public boolean isActive() {
        return isActive;
    }

    public void setActive(boolean active) {
        isActive = active;
    }
}
