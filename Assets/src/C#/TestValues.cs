using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using eu.parada.common;
using eu.parada.manager;
using System;

namespace eu.parada {
    public class TestValues : MonoBehaviour {

        public InputField MAXIMUM_SPREADING_KIDS;
        public InputField MAX_GAME_LENGTH;
        public InputField MIN_GAME_LENGTH;
        public InputField VIRUS_DIFFICULTY_CONSTANT;
        public InputField VITALS_DIFFICULTY_CONSTANT;
        public InputField REWARD_FOR_BUYING_IMMUNITY;
        public InputField REWARD_FOR_ANY_CELL_REPRODUCTION;
        public InputField REWARD_FOR_FIGHT;
        public InputField ENERGY_FOR_ONE_CELL_FIGHT;
        public InputField ENERGY_FOR_ONE_SLEEP;
        public InputField MAX_LOST_HEALTH_PER_LOST_ENERGY;
        public InputField IMUNITY_PRICE;
        public InputField PRICE_FOR_LEARNING;
        public InputField PRICE_FOR_WASHING_HANDS;
        public InputField PRICE_FOR_WEARING_PROTECTION;
        public InputField PRICE_FOR_SOCIAL_DISTANCING;
        public InputField PRICE_FOR_HEALTHY_REGIMEN;
        public InputField HARMNESS_FOR_VIRUS;
        public InputField MAX_HEALTH;
        public InputField STARTING_MONEY;
        public InputField STARTING_HEALTH;
        public InputField STARTING_ENERGY;
        public InputField LUNGS_CELL_CAPACITY;

        public bool loaded = false;
        // Update is called once per frame
        void Update() {
            if (!loaded) {
                MAXIMUM_SPREADING_KIDS.text = Constants.MAXIMUM_SPREADING_KIDS.ToString();
                MAX_GAME_LENGTH.text = Constants.MAX_GAME_LENGTH.ToString();
                MIN_GAME_LENGTH.text = Constants.MIN_GAME_LENGTH.ToString();
                VIRUS_DIFFICULTY_CONSTANT.text = Constants.VIRUS_DIFFICULTY_CONSTANT.ToString();
                VITALS_DIFFICULTY_CONSTANT.text = Constants.VITALS_DIFFICULTY_CONSTANT.ToString();
                REWARD_FOR_BUYING_IMMUNITY.text = Constants.REWARD_FOR_BUYING_IMMUNITY.ToString();
                REWARD_FOR_ANY_CELL_REPRODUCTION.text = Constants.REWARD_FOR_ANY_CELL_REPRODUCTION.ToString();
                REWARD_FOR_FIGHT.text = Constants.REWARD_FOR_FIGHT.ToString();
                ENERGY_FOR_ONE_CELL_FIGHT.text = Constants.ENERGY_FOR_ONE_CELL_FIGHT.ToString();
                ENERGY_FOR_ONE_SLEEP.text = Constants.ENERGY_FOR_ONE_SLEEP.ToString();
                MAX_LOST_HEALTH_PER_LOST_ENERGY.text = Constants.MAX_LOST_HEALTH_PER_LOST_ENERGY.ToString();
                IMUNITY_PRICE.text = Constants.IMUNITY_PRICE.ToString();
                PRICE_FOR_LEARNING.text = Constants.PRICE_FOR_LEARNING.ToString();
                PRICE_FOR_WASHING_HANDS.text = Constants.PRICE_FOR_WASHING_HANDS.ToString();
                PRICE_FOR_WEARING_PROTECTION.text = Constants.PRICE_FOR_WEARING_PROTECTION.ToString();
                PRICE_FOR_SOCIAL_DISTANCING.text = Constants.PRICE_FOR_SOCIAL_DISTANCING.ToString();
                PRICE_FOR_HEALTHY_REGIMEN.text = Constants.PRICE_FOR_HEALTHY_REGIMEN.ToString();
                HARMNESS_FOR_VIRUS.text = Constants.HARMNESS_FOR_VIRUS.ToString();
                MAX_HEALTH.text = Constants.MAX_HEALTH.ToString();
                STARTING_MONEY.text = Constants.STARTING_MONEY.ToString();
                STARTING_HEALTH.text = Constants.STARTING_HEALTH.ToString();
                STARTING_ENERGY.text = Constants.STARTING_ENERGY.ToString();
                LUNGS_CELL_CAPACITY.text = Constants.LUNGS_CELL_CAPACITY.ToString();
                loaded = true;
            }
        }

        public void back() {
            loaded = false;
            SceneManager.LoadScene(0);
            Manager.getInstance().stopGame();
        }

        public void save() {
            Constants.MAX_GAME_LENGTH = parseIntMaxValue(MAX_GAME_LENGTH, 100);
            Constants.MIN_GAME_LENGTH = parseIntMaxValue(MIN_GAME_LENGTH, 1);
            Constants.VIRUS_DIFFICULTY_CONSTANT = parseIntMaxValue(VIRUS_DIFFICULTY_CONSTANT, 10);
            Constants.VITALS_DIFFICULTY_CONSTANT = parseIntMaxValue(VITALS_DIFFICULTY_CONSTANT, 10);
            Constants.REWARD_FOR_BUYING_IMMUNITY = parseDoubleMaxValue(REWARD_FOR_BUYING_IMMUNITY, 100.0);
            Constants.REWARD_FOR_ANY_CELL_REPRODUCTION = parseDoubleMaxValue(REWARD_FOR_ANY_CELL_REPRODUCTION, 100.0);
            Constants.REWARD_FOR_FIGHT = parseDoubleMaxValue(REWARD_FOR_FIGHT, 100.0);
            Constants.ENERGY_FOR_ONE_CELL_FIGHT = parseDoubleMaxValue(ENERGY_FOR_ONE_CELL_FIGHT, 100.0);
            Constants.ENERGY_FOR_ONE_SLEEP = parseDoubleMaxValue(ENERGY_FOR_ONE_SLEEP, 100.0);
            Constants.MAX_LOST_HEALTH_PER_LOST_ENERGY = parseDoubleMaxValue(MAX_LOST_HEALTH_PER_LOST_ENERGY, 100.0);
            Constants.PRICE_FOR_LEARNING = parseDoubleMaxValue(PRICE_FOR_LEARNING, 10000.0);
            Constants.PRICE_FOR_WASHING_HANDS = parseDoubleMaxValue(PRICE_FOR_WASHING_HANDS, 10000.0);
            Constants.PRICE_FOR_WEARING_PROTECTION = parseDoubleMaxValue(PRICE_FOR_WEARING_PROTECTION, 10000.0);
            Constants.PRICE_FOR_SOCIAL_DISTANCING = parseDoubleMaxValue(PRICE_FOR_SOCIAL_DISTANCING, 10000.0);
            Constants.PRICE_FOR_HEALTHY_REGIMEN = parseDoubleMaxValue(PRICE_FOR_HEALTHY_REGIMEN, 10000.0);
            Constants.IMUNITY_PRICE = parseDoubleMaxValue(IMUNITY_PRICE, 10000.0);
            Constants.HARMNESS_FOR_VIRUS = parseDoubleMaxValue(HARMNESS_FOR_VIRUS, 10.0);
            Constants.MAX_HEALTH = parseDoubleMaxValue(MAX_HEALTH, 100.0);
            Constants.STARTING_MONEY = parseDoubleMaxValue(STARTING_MONEY, 99999999.0);
            Constants.STARTING_HEALTH = parseDoubleMaxValue(STARTING_HEALTH, 100.0);
            Constants.STARTING_ENERGY = parseDoubleMaxValue(STARTING_ENERGY, 100.0);
            Constants.LUNGS_CELL_CAPACITY = parseIntMaxValue(LUNGS_CELL_CAPACITY, 99999999);
            loaded = true;
        }

        private int parseIntMaxValue(InputField field, int maxValue) {
            int value = Int32.Parse(field.text);
            if (value > maxValue || value < 0) {
                return maxValue;
            }

            return value;
        }

        private double parseDoubleMaxValue(InputField field, double maxValue) {
            double value = double.Parse(field.text);
            if (value > maxValue || value < 0) {
                return maxValue;
            }

            return value;
        }

    }
}