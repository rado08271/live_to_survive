using System.Collections;
using System.Collections.Generic;

namespace eu.parada.common {
	public class Constants {
        // TODO: DELETE THIS IT'S ONLY FOR TESTING
        public const string TESTER_NAME = "TESTER";
        public const double TESTER_DIFFICULTY = 0.99;

        // THIS IS FOR SPREADING
        public const int MAXIMUM_SPREADING_KIDS = 3;
        public const int STARTING_SPREADING_IMMUNITY = 1;
        public const int STARTING_SPREADING_VIRUS = MAXIMUM_SPREADING_KIDS;

        // GAME TIME AND DIFFICULTY
        public const int MAX_GAME_LENGTH = 28;
        public const int MIN_GAME_LENGTH = 7;
        public const int VIRUS_DIFFICULTY_CONSTANT = 5;
        public const int VITALS_DIFFICULTY_CONSTANT = 2;

        // REWARDS FOR DNA
        public const double REWARD_FOR_BUYING_IMMUNITY = 0.5;
        public const double REWARD_FOR_ANY_CELL_REPRODUCTION = 0.25;
        public const double REWARD_FOR_FIGHT = 1;

        // ENERGY
        public const double ENERGY_FOR_ONE_CELL_FIGHT = 1;
        public const double ENERGY_FOR_ONE_SLEEP = 20;
        public const double MAX_LOST_HEALTH_PER_LOST_ENERGY = 2.5;

        // EFFECT PRICES
        public const double PRICE_FOR_LEARNING = 5;
        public const double PRICE_FOR_WASHING_HANDS = 15;
        public const double PRICE_FOR_WEARING_PROTECTION = 25;
        public const double PRICE_FOR_SOCIAL_DISTANCING = 35;
        public const double PRICE_FOR_HEALTHY_REGIMEN = 45;
        public const double IMUNITY_PRICE = 1;

        // HARMNESS VALUES
        public const double HARMNESS_FOR_CELL = 0;
        public const double HARMNESS_FOR_IMUNITY = 1.2;
        public const double HARMNESS_FOR_VIRUS = 1.3;

        // VITALS STATS
        public const double MAX_HEALTH = 100;
        //public const double HEALTH_DIVIDE_CONSTANT = 1; //TODO: This will be done more generic maybe...
        public const double HEALTH_DIVIDE_CONSTANT = LUNGS_CELL_CAPACITY / MAX_HEALTH;    //TODO: This will be done more generic maybe...
        public const double STARTING_MONEY = 0;
        public const double STARTING_HEALTH = MAX_HEALTH;
        public const double STARTING_ENERGY = MAX_HEALTH;

        // CELLS
        public const int LUNGS_CELL_CAPACITY = 300;
    }
}