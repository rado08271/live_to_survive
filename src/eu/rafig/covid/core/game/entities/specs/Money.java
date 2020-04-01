package eu.rafig.covid.core.game.entities.specs;

public class Money {
    private double currentMoney = 0;

    public Money(double currentMoney) {
        this.currentMoney = currentMoney;
    }

    public boolean butStuff(int price){
        if (currentMoney - price < 0 ) return false;
        currentMoney -= price;
        return true;
    }

    public boolean butStuff(double price){
        return butStuff((int) price);
    }

    public double getCurrentMoney() {
        return currentMoney;
    }

    public void earnMoney(int earned) {
        currentMoney += earned;
    }
}
