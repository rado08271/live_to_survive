using System.Collections;
using System.Collections.Generic;

namespace eu.parada.common {
	public class Constants {
        // TODO: DELETE THIS IT'S ONLY FOR TESTING
        public const string TESTER_NAME = "TESTER";
        public const double TESTER_DIFFICULTY = 0.5;

        // THIS IS FOR SPREADING
        public static int MAXIMUM_SPREADING_KIDS = 3;
        public static int STARTING_SPREADING_IMMUNITY = 1;
        public static int STARTING_SPREADING_VIRUS = MAXIMUM_SPREADING_KIDS;

        // GAME TIME AND DIFFICULTY
        public static int MAX_GAME_LENGTH = 28;
        public static int MIN_GAME_LENGTH = 7;
        public static int VIRUS_DIFFICULTY_CONSTANT = 5;
        public static int VITALS_DIFFICULTY_CONSTANT = 2;

        // REWARDS FOR DNA
        public static double REWARD_FOR_BUYING_IMMUNITY = 0.5;
        public static double REWARD_FOR_ANY_CELL_REPRODUCTION = 0.25;
        public static double REWARD_FOR_FIGHT = 1;

        // ENERGY
        public static double ENERGY_FOR_ONE_CELL_FIGHT = 1;
        public static double ENERGY_FOR_ONE_SLEEP = 20;
        public static double MAX_LOST_HEALTH_PER_LOST_ENERGY = 2.5;

        // EFFECT PRICES
        public static double PRICE_FOR_LEARNING = 5;
        public static double PRICE_FOR_WASHING_HANDS = 15;
        public static double PRICE_FOR_WEARING_PROTECTION = 25;
        public static double PRICE_FOR_SOCIAL_DISTANCING = 35;
        public static double PRICE_FOR_HEALTHY_REGIMEN = 45;
        public static double IMUNITY_PRICE = 1;

        // HARMNESS VALUES
        public static double HARMNESS_FOR_CELL = 0;
        public static double HARMNESS_FOR_IMUNITY = 1.2;
        public static double HARMNESS_FOR_VIRUS = 1.3;

        // VITALS STATS
        public static double MAX_HEALTH = 100;
        //public const double HEALTH_DIVIDE_CONSTANT = 1; //TODO: This will be done more generic maybe...
        public static double HEALTH_DIVIDE_CONSTANT = LUNGS_CELL_CAPACITY / MAX_HEALTH;    //TODO: This will be done more generic maybe...
        public static double STARTING_MONEY = 0;
        public static double STARTING_HEALTH = MAX_HEALTH;
        public static double STARTING_ENERGY = MAX_HEALTH;

        // CELLS
        public static int LUNGS_CELL_CAPACITY = 300;
    }
}