using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using eu.parada.game;
using eu.parada.manager;
using eu.parada.enums;
using eu.parada.common;
using eu.parada.entities.events;

namespace eu.parada {
    public class Game : MonoBehaviour {

        //private GamePlay gamePlay = null;
        private GamePlay gamePlay = Manager.getInstance().getGamePlay();
        private bool newScene = false;
        public GameObject loadingScreen;
        private bool loaded = false;
        public AudioManger audioChannel;

        void Start() {
            StartCoroutine(initNewGame(2));
        }

        private IEnumerator initNewGame(int secondsForInitialization) {
            // FIXME: Delete on stage...
            loadingScreen.SetActive(true);
            yield return new WaitForSeconds(secondsForInitialization);
            loadingScreen.SetActive(false);
            if (!newScene) {
                if (gamePlay == null) {
                    if (Manager.getInstance().getGamePlay() == null) {
                        Debug.Log("No game found initializing test game!");
                        // FIXME this is only for testing puposes
                        Manager.getInstance().initNewGame(Constants.TESTER_NAME, Constants.TESTER_DIFFICULTY);
                    }

                    this.gamePlay = Manager.getInstance().getGamePlay();

                }
                newScene = true;
                loaded = true;
            }
        }

        public AudioManger getAudioChannel() {
            return audioChannel;
        }

        public bool seenInitialScreen() {
            return gamePlay.seenInitialScreen();
        }

        public void showInitScreen() {
            gamePlay.showInitialScreen();
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
            bool result = gamePlay.newDay();

            if (getCurrentDay() + 1 >= getMaxDays()) {
                audioChannel.playTimeTickingSound();
            } else {
                if (result) {
                    audioChannel.playNewDaySound();
                } else {
                    //audioChannel.playNoSound();
                }
            }

            return result;
        }

        public bool fight() {
            //Debug.Log("Fighting with fire");
            bool result = gamePlay.attack();

            if (result && getEnergy() >= 1) {
                audioChannel.playFightSound();
            } else if (!result && getCurrentDayTime() == DayTime.SLEEP) {
                audioChannel.playSleepingSound();
            } else {
                audioChannel.playTiredSound();
            }

            return result;
        }

        public bool buyEffects(int effectNumber) {
            //Debug.Log("Buying effect: " + effectNumber);
            bool result = gamePlay.buy(effectNumber);


            return result;
        }

        //TOOD: Show effects when money available
        public int showEffects() {
            //Debug.Log("Getting effects");
            return PositiveEffects.getEffectList().Count;
        }

        public int effectBonus() {
            return PositiveEffects.bonus;
        }

        public int showNewDayHealth() {
            return (int) gamePlay.changedHealth();
        }

        public bool buyImmunity(int count) {
            //Debug.Log("Buying immunity: " + count);
            bool result = gamePlay.buySomeImmunity(count);

            if (result) {
                audioChannel.playBoughtImmunitySound();
            } else {
                audioChannel.playNoSound();
            }

            return result;
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
        
        public int getMaxDays() {
            return gamePlay.getMaxDays();
        }

        public void help() {
            //TODO: todoooo todo toodooo ododododo
        }

        public bool exit(bool showScreen) {
            //Debug.Log("Stopping the game");

            loaded = false;
            
            // UNLOADING PROCESS
            SceneManager.UnloadScene(SceneManager.GetActiveScene());
            Resources.UnloadUnusedAssets();
            Destroy(this);

            // FIXME: It changes earlier than last async call to Update()!
            // showScreen is called only if lost/won game
            if (!showScreen) {
                SceneManager.LoadScene(0, LoadSceneMode.Single);
            } else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
            }

            // VARS UNSETTING PROCESS
            loadingScreen.SetActive(true);
            newScene = false;

            return false;
        }
        public bool isLoaded() {
            return loaded;
        }

        public StringMessage getRandomFact() {
            int randomNumber = Randomizer.getRandomNumberMax(Constants.POSSIBILITY_OF_GETTING_MESSAGE);

            return gamePlay.getFact(randomNumber);
        }
    }
}