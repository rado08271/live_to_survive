using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using eu.parada.enums;
using eu.parada.common;

namespace eu.parada.manager {
    public class GamePlayManager : MonoBehaviour {

        public Game game;

        public Text currentLungsStatusText;
        public GameObject animationAlive;
        public GameObject animationInfected;
        public GameObject animationDead;

        public Text nextDayViruses;
        public Text nextDayImmunity;
        public Text nextDayMoney;
        public Text nextDayDay;
        public Text nextDayEnergy;
        public Text nextDayHealth;

        public Text fightDNA;
        public Text fightVirus;
        public Text fightImmunity;
        public Text fightEnergy;

        // Update is called once per frame
        void Update() {
            if (game.isLoaded()) {

                currentLungsStatusText.text = game.getLungsState().ToString();

                status();
                viruses();
                immunities();
                money();
                day();
                energy();
                health();
                dnaFightReward();
                virusFight();
                immunityFight();
                energyFight();
            }
        }

        private void status() {
            if (game.getLungsState() == LungsState.INFECTED) {
                animationAlive.SetActive(false);
                animationInfected.SetActive(true);
                animationDead.SetActive(false);
            } else if (game.getLungsState() == LungsState.DESTROYED) {
                animationAlive.SetActive(false);
                animationInfected.SetActive(false);
                animationDead.SetActive(true);
            } else {
                animationAlive.SetActive(true);
                animationInfected.SetActive(false);
                animationDead.SetActive(false);
            }
        }

        private int viruses() {
            int min = game.getUserViruses();
            int max = min * (Constants.MAXIMUM_SPREADING_KIDS - game.effectBonus()) + (game.showEffects() - game.effectBonus());
            nextDayViruses.text = ("Virus: " + min + " - " + max + "");
            return max;
        }

        private int immunities() {
            int min = game.getUserImmunity();
            int max = min * ((game.effectBonus() == 0) ? 1 : game.effectBonus());
            nextDayImmunity.text = ("Immunity: " + min + " - " + max + "");
            return max;
        }

        private void money() {
            // minimum money
            int minForLabor = (int)(game.getUserImmunity() * Constants.REWARD_FOR_BUYING_IMMUNITY);
            int minForReproduction = (int)((game.getUserImmunity() + game.getUserViruses()) * Constants.REWARD_FOR_ANY_CELL_REPRODUCTION);

            int maxForLabor = (int)(immunities() * Constants.REWARD_FOR_BUYING_IMMUNITY);
            int maxForReproduction = (int)((immunities() + viruses()) * Constants.REWARD_FOR_ANY_CELL_REPRODUCTION);

            int currentMoney = game.getDna();

            nextDayMoney.text = ("DNA: " + (currentMoney + minForLabor + minForReproduction) + " - " + (currentMoney + maxForLabor + maxForReproduction) + "");
        }

        private void day() {
            nextDayDay.text = ("Day: " + (game.getCurrentDay() + 1).ToString() + "");

        }

        private void energy() {
            int energy = (int)(game.getEnergy() + Constants.ENERGY_FOR_ONE_SLEEP);
            if (energy >= Constants.MAX_HEALTH) energy = (int)Constants.MAX_HEALTH;

            nextDayEnergy.text = ("Energy: " + energy.ToString() + "");
        }

        private void health() {
            int health = (int)(game.getHealth() - (game.showNewDayHealth() / (Constants.LUNGS_CELL_CAPACITY / Constants.MAX_HEALTH)));
            if (health <= 0) health = 0;

            nextDayHealth.text = ("Health: " + health.ToString() + "");
        }

        private void dnaFightReward() {
            fightDNA.text = "TODO";
        }

        private void virusFight() {
            fightVirus.text = "TODO";
        }

        private void immunityFight() {
            fightImmunity.text = "TODO";
        }

        private void energyFight() {
            fightEnergy.text = "TODO";
        }
    }
}