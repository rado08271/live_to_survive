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
    public static final double REWARD_FOR_FIGHT = 0.8;

    // ENERGY
    public static final double ENERGY_FOR_ONE_CELL_FIGHT = 2;
    public static final double ENERGY_FOR_ONE_SLEEP = 20;
    public static final double MAX_LOST_HEALTH_PER_LOST_ENERGY = 5;

    // EFFECT PRICES
    public static final double PRICE_FOR_WASHING_HANDS = 15;
    public static final double PRICE_FOR_WEARING_PROTECTION = 25;
    public static final double PRICE_FOR_SOCIAL_DISTANCING = 35;
    public static final double PRICE_FOR_HEALTHY_REGIMEN = 45;
    public static final double PRICE_FOR_LEARNING = 5;
    public static final double IMMUNITY_PRICE = 1;

    // HARMNESS VALUES
    public static final double HARMNESS_FOR_CELL = 0;
    public static final double HARMNESS_FOR_IMUNITY = 1.2;
    public static final double HARMNESS_FOR_VIRUS = 1.3;

    // VITALS STATS
    public static final double MAX_HEALTH = 100;
    public static final double HEALTH_DIVIDE_CONSTANT = 5;     //TODO: This will be done more generic maybe...
    public static final double STARTING_MONEY = 0;
    public static final double STARTING_HEALTH = MAX_HEALTH;
    public static final double STARTING_ENERGY = MAX_HEALTH;

    // CELLS
    public static final int LUNGS_CELL_CAPACITY = 300;

}
