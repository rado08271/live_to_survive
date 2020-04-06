using System.Collections;
using System.Collections.Generic;

namespace eu.parada.common {
	public class Constants {
        // THIS IS FOR SPREADING
        public const int MAXIMUM_SPREADING_KIDS = 3;
        public const int STARTING_SPREADING_IMMUNITY = 1;
        public const int STARTING_SPREADING_VIRUS = MAXIMUM_SPREADING_KIDS;

        // GAME TIME
        public const int GAME_LENGTH = 14;

        // REWARDS FOR DNA
        public const double REWARD_FOR_BUYING_IMMUNITY = 0.5;
        public const double REWARD_FOR_ANY_CELL_REPRODUCTION = 0.25;
        public const double REWARD_FOR_FIGHT = 1;

        // ENERGY
        public const double ENERGY_FOR_ONE_CELL_FIGHT = 2;
        public const double ENERGY_FOR_ONE_SLEEP = 20;
        public const double MAX_LOST_HEALTH_PER_LOST_ENERGY = 2.5;

        // EFFECT PRICES
        public const double PRICE_FOR_WASHING_HANDS = 20;
        public const double PRICE_FOR_WEARING_PROTECTION = 20;
        public const double PRICE_FOR_SOCIAL_DISTANCING = 20;
        public const double PRICE_FOR_HEALTHY_REGIMEN = 20;
        public const double PRICE_FOR_LEARNING = 20;

        // HARMNESS VALUES
        public const double HARMNESS_FOR_CELL = 0;
        public const double HARMNESS_FOR_IMUNITY = 1.1;
        public const double HARMNESS_FOR_VIRUS = 1.14;

        // VITALS STATS
        public const double MAX_HEALTH = 100;
        public const double HEALTH_DIVIDE_CONSTANT = 5; //TODO: This will be done more generic maybe...
        public const double STARTING_MONEY = 0;
        public const double STARTING_HEALTH = MAX_HEALTH;
        public const double STARTING_ENERGY = MAX_HEALTH;

        // CELLS
        public const int LUNGS_CELL_CAPACITY = 150;
    }
}