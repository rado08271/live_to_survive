using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using eu.parada.game;
using eu.parada.enums;

namespace eu.parada.game {
    public class Game : MonoBehaviour {

        public GamePlay gamePlay = null;

        public Game(Input userName) {
            this.gamePlay = new GamePlay(userName.ToString());
        }

        public int getEnergy() {
            return (int) gamePlay.lungs.vitals.energy.currentEnergy;
        }

        public int getHealth() {
            return (int) gamePlay.lungs.vitals.health.currentHealth;
        }

        public int getDna() {
            return (int) gamePlay.lungs.vitals.money.currentMoney;
        }

        public string getUserName() {
            return gamePlay.user.name;
        }

        public int getUserScore() {
            return gamePlay.user.score;
        }

        public LungsState getLungsState() {
            return gamePlay.lungs.lungsState;
        }

        public GameState getGameState() {
            return gamePlay.gameState;
        }

        public bool nextTurn() {
            return gamePlay.newDay();
        }

        public bool fight() {
            return gamePlay.attack();
        }

        public bool buyEffects() {
            return gamePlay.buy(0);
        }

        //TOOD: Show effects when money available
        public int showEffects() {
            return -1;
        }

        public bool buyImmunity() {
            return gamePlay.buySomeImmunity(0);
        }

        //show some kind of picker with max of money
        public int showImmunityToBuy() {
            return -1;
        }

        public void help() {
            //TODO: todoooo todo toodooo ododododo
        }

        public bool exit() {
            return false;
        }

        public bool pause() {
            return false;
        }

    }
}