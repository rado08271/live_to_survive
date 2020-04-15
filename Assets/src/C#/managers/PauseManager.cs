using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using eu.parada.game;

namespace eu.parada.manager {
    public class PauseManager : MonoBehaviour {

        public Game game;
        public void pauseGame() {
            Debug.Log("Game Paused");
        }

        //TODO: Add whether lost/won/self quit...!!!
        public void quitGame() {
            game.exit(false);
        }

    }
}
