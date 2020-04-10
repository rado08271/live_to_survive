package eu.rafig.covid.core.game.entities.effects;

//TODO: if effects are more complex then redefine each effect
public class Effect {
    private String desciption;
    private boolean isActive;
    private double dnaPrice;
    private double spreading;
    private double energy;
    private double reprduction;

    public Effect(String desciption, double dnaPrice) {
        this.desciption = desciption;
        this.isActive = false;
        this.dnaPrice = dnaPrice;
    }

    public Effect(String desciption, double dnaPrice, double spreading, double energy, double reprduction) {
        this.desciption = desciption;
        this.dnaPrice = dnaPrice;
        this.spreading = spreading;
        this.energy = energy;
        this.reprduction = reprduction;
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

    public double getSpreading() {
        return spreading;
    }

    public double getEnergy() {
        return energy;
    }

    public double getReprduction() {
        return reprduction;
    }

}
