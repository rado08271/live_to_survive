package eu.rafig.covid.core.game.common;

public class Constants {
    // THIS IS FOR SPREADING
    public static final int MAXIMUM_SPREADING_KIDS = 3;
    public static final int STARTING_SPREADING_IMMUNITY = 1;
    public static final int STARTING_SPREADING_VIRUS = MAXIMUM_SPREADING_KIDS;

    // GAME TIME
    public static final int GAME_LENGTH = 14;

    // REWARDS FOR DNA
    public static final double REWARD_FOR_BUYING_IMMUNITY = 0.5;
    public static final double REWARD_FOR_ANY_CELL_REPRODUCTION = 0.25;
    public static final double REWARD_FOR_FIGHT = 0;

    // EFFECT PRICES
    public static final double PRICE_FOR_WASHING_HANDS = 20;
    public static final double PRICE_FOR_WEARING_PROTECTION = 20;
    public static final double PRICE_FOR_SOCIAL_DISTANCING = 20;
    public static final double PRICE_FOR_HEALTHY_REGIMEN = 20;
    public static final double PRICE_FOR_LEARNING = 20;

    // HARMNESS VALUES
    public static final double HARMNES_FOR_CELL = 0;
    public static final double HARMNESS_FOR_IMUNITY = 1.1;
    public static final double HARMNESS_FOR_VIRUS = 1.14;

    // VITALS STATS
    public static final double MAX_HEALTH = 100;
    public static final double HEALTH_DIVIDE_CONSTANT = 10;     //TODO: This will be done more generic maybe...
    public static final double STARTING_MONEY = 0;

    // CELLS
    public static final int LUNGS_CELL_CAPACITY = 150;


}
