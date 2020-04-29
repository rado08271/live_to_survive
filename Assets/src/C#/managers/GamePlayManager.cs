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

        private LungsState state = LungsState.DESTROYED;

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
            }
        }

        private void status() {
            if (game.getLungsState() != state) {
                Debug.Log("Changed state to");
                if (game.getLungsState() == LungsState.INFECTED) {
                    Debug.Log("INFECTED");
                    animationAlive.SetActive(false);
                    animationInfected.SetActive(true);
                    animationDead.SetActive(false);
                    state = LungsState.INFECTED;
                    game.getAudioChannel().playFastHeartBeat();
                } else if (game.getLungsState() == LungsState.DESTROYED || game.getHealth() <= 0) {
                    Debug.Log("DESTROYED");
                    animationAlive.SetActive(false);
                    animationInfected.SetActive(false);
                    animationDead.SetActive(true);
                    state = LungsState.DESTROYED;
                    game.getAudioChannel().playNNoHeartBeat();
                } else if (game.getLungsState() == LungsState.WORKING) {
                    Debug.Log("WORKING");
                    animationAlive.SetActive(true);
                    animationInfected.SetActive(false);
                    animationDead.SetActive(false);
                    state = LungsState.WORKING;
                    game.getAudioChannel().playSlowHeartBeat();
                } else if (game.getLungsState() == LungsState.CURED) {
                    Debug.Log("CURED");
                    animationAlive.SetActive(true);
                    animationInfected.SetActive(false);
                    animationDead.SetActive(false);
                    state = LungsState.CURED;
                    game.getAudioChannel().playSlowHeartBeat();
                }
            }
        }

        private int viruses() {
            int min = game.getUserViruses();
            int max = min * (Constants.MAXIMUM_SPREADING_KIDS - game.effectBonus()) + (game.showEffects() - game.effectBonus());
            if (max <= min) max = min;
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
            if (game.getCurrentDay() + 2 > game.getMaxDays()) {
                nextDayDay.text = ("Day: " + ("Hurry Up!").ToString() + "");
            } else {
                nextDayDay.text = ("Day: " + (game.getCurrentDay() + 2).ToString() + "");
            }
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
            int virusesCount = (game.getUserViruses() - game.getUserImmunity()) >= 0 ? (game.getUserViruses() - game.getUserImmunity()) : 0;
            int imunitieCounts = (game.getUserImmunity() - game.getUserViruses()) >= 0 ? (game.getUserImmunity() - game.getUserViruses()) : 0;

            double tmpEnergy = game.getEnergy();
            // You do not have any energy
            if ((game.getUserImmunity() - imunitieCounts) * Constants.ENERGY_FOR_ONE_CELL_FIGHT < 0) {
                imunitieCounts = game.getUserImmunity() - (int)tmpEnergy;
                virusesCount = game.getUserImmunity() - (int)tmpEnergy;
            }

            virusFight(virusesCount);
            immunityFight(imunitieCounts);
            energyFight((int) (tmpEnergy - (game.getUserImmunity() - imunitieCounts) * Constants.ENERGY_FOR_ONE_CELL_FIGHT));

            fightDNA.text = (game.getUserImmunity() - imunitieCounts * Constants.REWARD_FOR_FIGHT).ToString();
        }

        private void virusFight(int value) {
            fightVirus.text = value.ToString();
        }

        private void immunityFight(int value) {
            fightImmunity.text = value.ToString();
        }

        private void energyFight(int value) {
            fightEnergy.text = value.ToString();
        }
    }
}