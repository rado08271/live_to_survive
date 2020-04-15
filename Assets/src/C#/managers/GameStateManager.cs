using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using eu.parada.enums;
using eu.parada.game;

namespace eu.parada.manager {
    public class GameStateManager : MonoBehaviour {
        public Game mainGame;

        private BaseState state = BaseState.INPROGRESS;

        void Update() {
            if (mainGame.isLoaded()) {
                GamePlay gamePlay = Manager.getInstance().getGamePlay();

                if (state == BaseState.INPROGRESS) {
                    if (gamePlay.gameState == GameState.FAILED) {
                        Debug.LogError("Sorry virus beaten you...*Nearer My Go to Thee * plays in the background.Your corpse smells terrible.\n You should be more concise in the future! Look at the man next to you he is also dead. Good news is that there are not many like you");
                        state = BaseState.LOST;
                    } else if (gamePlay.gameState == GameState.NOTIME) {
                        Debug.LogError("You finished the game!");

                        if (gamePlay.lungs.lungsState == LungsState.CURED) {
                            Debug.LogError("And you won! Congratulation there are many like you!");
                            state = BaseState.WON;
                        } else if (gamePlay.lungs.lungsState == LungsState.INFECTED) {
                            Debug.LogError("And you are still infected. But good fight, but you are still infected I don't think you will be able to survive next days");
                            state = BaseState.LOST;
                        } else if (gamePlay.lungs.lungsState == LungsState.WORKING) {
                            Debug.LogError("And you didn't get infected?! You cheater! Okay I think it's honest to say that you find your own way to beating this game");
                            state = BaseState.WON;
                        } else if (gamePlay.lungs.lungsState == LungsState.DESTROYED) {
                            Debug.LogError("*Nearer My Go to Thee* plays in the background. Your corpse smells terrible");
                            state = BaseState.LOST;
                        }
                    } else if (gamePlay.gameState == GameState.PLAYING) {
                        // nothing
                        state = BaseState.INPROGRESS;
                    } else if (gamePlay.gameState == GameState.WON) {
                        Debug.LogError("Congratulations, " + gamePlay.user.name + " you finished the game in " + gamePlay.getCurrentDay() + " days. Your final score is: " + gamePlay.user.score);
                        state = BaseState.WON;
                    } else {
                        Debug.LogError("Uhm I don't know how, but you reached matrix");
                        state = BaseState.DONE;
                    }
                } else {
                    mainGame.exit(true);
                }
            }
        }
    }
}
