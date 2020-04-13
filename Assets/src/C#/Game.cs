using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using eu.parada.game;
using eu.parada.manager;
using eu.parada.enums;

namespace eu.parada {
    public class Game : MonoBehaviour {

        //private GamePlay gamePlay = null;
        private GamePlay gamePlay = Manager.getInstance().getGamePlay();
        private bool newScene = false;

        void Update () {
            if (!newScene) {
                if (gamePlay == null) {
                    if (Manager.getInstance().getGamePlay() == null) {
                        Debug.Log("No game found initializing test game!");
                        // FIXME this is only for testing puposes
                        // Manager.getInstance().initNewGame("Tester", 0.23);
                    }

                    this.gamePlay = Manager.getInstance().getGamePlay();

                }
                newScene = true;

            }
        }

        public LungsState getLungsState() {
            //Debug.Log("Get lungs state");
            return gamePlay.lungs.lungsState;
        }

        public GameState getGameState() {
            //Debug.Log("Get game state");
            return gamePlay.gameState;
        }

        public bool nextTurn() {
            //Debug.Log("Finishing day: " + getCurrentDay());
            return gamePlay.newDay();
        }

        public bool fight() {
            //Debug.Log("Fighting with fire");
            return gamePlay.attack();
        }

        public bool buyEffects(int effectNumber) {
            //Debug.Log("Buying effect: " + effectNumber);
            return gamePlay.buy(effectNumber);
        }

        //TOOD: Show effects when money available
        public int showEffects() {
            //Debug.Log("Getting effects");
            return -1;
        }

        public bool buyImmunity(int count) {
            //Debug.Log("Buying immunity: " + count);
            return gamePlay.buySomeImmunity(count);
        }

        //show some kind of picker with max of money
        public int showImmunityToBuy() {
            //Debug.Log("Showing possible immunities");
            return -1;
        }
        public int getEnergy() {
            //Debug.Log("Getting energy: " + (int)gamePlay.lungs.vitals.energy.currentEnergy);
            return (int)gamePlay.lungs.vitals.energy.currentEnergy;
        }

        public int getHealth() {
            //Debug.Log("Getting health: " + (int)gamePlay.lungs.vitals.health.currentHealth);
            return (int)gamePlay.lungs.vitals.health.currentHealth;
        }

        public int getDna() {
            //Debug.Log("Getting money: " + (int)gamePlay.lungs.vitals.money.currentMoney);
            return (int)gamePlay.lungs.vitals.money.currentMoney;
        }

        public string getUserName() {
            //Debug.Log("Getting user name: " + gamePlay.user.name);
            return gamePlay.user.name;
        }

        public int getUserScore() {
            //Debug.Log("Getting user score: " + gamePlay.user.score);
            return (int)gamePlay.user.score;
        }

        public int getUserCells() {
            //Debug.Log("Getting Cells: " + gamePlay.lungs.cells.Count);
            return gamePlay.lungs.cells.Count;
        }

        public int getUserViruses() {
            //Debug.Log("Getting viruses: " + gamePlay.lungs.viruses.Count);
            return gamePlay.lungs.viruses.Count;
        }

        public int getUserImmunity() {
            //Debug.Log("Getting immunity: " + gamePlay.lungs.imunities.Count);
            return gamePlay.lungs.imunities.Count;
        }

        public int getCurrentDay() {
            //Debug.Log("Getting current day: " + gamePlay.getCurrentDay());
            return gamePlay.getCurrentDay();
        }

        public DayTime getCurrentDayTime() {
            //Debug.Log("Getting current time of the day: " + gamePlay.lungs.dayTime.ToString());
            return gamePlay.lungs.dayTime;
        }

        public int getDay() {
            //Debug.Log("Getting current time of the day: " + gamePlay.lungs.getKindaTime().ToString());
            return gamePlay.lungs.getKindaTime();
        }

        public void help() {
            //TODO: todoooo todo toodooo ododododo
        }

        public bool exit() {
            //Debug.Log("Stopping the game");
            newScene = false;
            Manager.getInstance().stopGame();
            return false;
        }
    }
}