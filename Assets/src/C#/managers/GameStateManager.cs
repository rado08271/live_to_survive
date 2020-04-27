using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using eu.parada.enums;
using eu.parada.game;
using eu.parada.common;

namespace eu.parada.manager {
    public class GameStateManager : MonoBehaviour {
        public Game mainGame;

        private BaseState state = BaseState.INPROGRESS;

        void Update() {
            if (mainGame.isLoaded()) {
                GamePlay gamePlay = Manager.getInstance().getGamePlay();

                if (state == BaseState.INPROGRESS) {
                    if (gamePlay.gameState == GameState.FAILED) {
                        Debug.Log(StringConstant.LOST_GAME_FAILED_DEAD);
                        state = BaseState.LOST;
                    } else if (gamePlay.gameState == GameState.NOTIME) {
                        Debug.Log(StringConstant.NO_TIME_BASIC);

                        if (gamePlay.lungs.lungsState == LungsState.CURED) {
                            Debug.Log(StringConstant.NO_TIME_GAME_WON);
                            state = BaseState.WON;
                        } else if (gamePlay.lungs.lungsState == LungsState.INFECTED) {
                            Debug.Log(StringConstant.NO_TIME_LOST_INFECTED);
                            state = BaseState.LOST;
                        } else if (gamePlay.lungs.lungsState == LungsState.WORKING) {
                            Debug.Log(StringConstant.NO_TIME_LOST_NOT_INFECTED);
                            state = BaseState.WON;
                        } else if (gamePlay.lungs.lungsState == LungsState.DESTROYED) {
                            Debug.Log(StringConstant.NO_TIME_LOST_DEAD);
                            state = BaseState.LOST;
                        }
                    } else if (gamePlay.gameState == GameState.PLAYING) {
                        // nothing
                        state = BaseState.INPROGRESS;
                    } else if (gamePlay.gameState == GameState.WON) {
                        Debug.Log(StringConstant.WON_GAME_STATE);
                        state = BaseState.WON;
                    } else {
                        Debug.Log(StringConstant.UNKNOWN_GAMESTATE_ERROR);
                        state = BaseState.DONE;
                    }
                } else {
                    mainGame.exit(true);
                }
            }
        }
    }
}
