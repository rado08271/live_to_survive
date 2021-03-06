﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using eu.parada.game;
using eu.parada.manager;
using eu.parada.enums;
using eu.parada.common;

namespace eu.parada {
    public class PostGame : MonoBehaviour {

        public GameObject backgroundWon;
        public GameObject backgroundLost;
        public GameObject loading;

        public Text gameResult;

        public Text gameResultInfo;

        public Text userName;
        public Text userScore;
        public Text days;
        public Text effectsAvailable;
        public Text money;

        private bool loaded = false;
        private bool init = false;
        private GamePlay game = Manager.getInstance().getGamePlay();

        void Setup() {
        }

        // Update is called once per frame
        void Update() {
            if ( !init ) {
                StartCoroutine(initGameAfter(1));
                init = true;
            }

            if (loaded) {
                if ( game.gameState == GameState.FAILED) {
                    gameResult.text = game.user.name + "!\n " + StringConstant.LOST_GAME_FAILED_DEAD;
                    backgroundWon.gameObject.SetActive(false);
                    backgroundLost.gameObject.SetActive(true);
                } else if (game.gameState == GameState.NOTIME) {
                    gameResult.text = game.user.name + "! " + StringConstant.NO_TIME_BASIC;
                    backgroundWon.gameObject.SetActive(false);
                    backgroundLost.gameObject.SetActive(true);
                } else if (game.gameState == GameState.WON) {
                    gameResult.text = game.user.name + "! " + StringConstant.WON_GAME_STATE;
                    backgroundWon.gameObject.SetActive(true);
                    backgroundLost.gameObject.SetActive(false);
                } else {
                    gameResult.text = StringConstant.UNKNOWN_GAMESTATE_ERROR;
                    backgroundWon.gameObject.SetActive(false);
                    backgroundLost.gameObject.SetActive(false);
                }

                userName.text = "Player " + game.user.name;
                userScore.text = "Your final score is " + game.user.score.ToString();
                days.text = "It took you " + game.getCurrentDay().ToString() + " out of " + game.getMaxDays() + " days";
                money.text = "Final DNA " + ((int) game.lungs.vitals.money.currentMoney).ToString();
                effectsAvailable.text = "You gained " + game.lungs.boughtEffects.Count.ToString() + " knowledge out of 5";
            }
        }

        public void quitGame() {
            // UNLOADING PROCESS
            loaded = false;

            Manager.getInstance().stopGame();
            SceneManager.UnloadScene(SceneManager.GetActiveScene());
            Resources.UnloadUnusedAssets();
            Destroy(this);

            SceneManager.LoadScene(0, LoadSceneMode.Single);

            Manager.getInstance().stopGame();
        }

        private IEnumerator initGameAfter(int seconds) {
            loading.SetActive(true);
            yield return new WaitForSeconds(seconds);
            loading.SetActive(false);
            game = Manager.getInstance().getGamePlay();
            if ( game != null) loaded = true;      
        }
    }
}