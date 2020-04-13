﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using eu.parada.game;

namespace eu.parada.manager {
    public class PauseManager : MonoBehaviour {

        public Game game;
        public void pauseGame() {
            Debug.Log("Game Paused");
        }

        public void quitGame() {
            game.exit();

            SceneManager.UnloadScene(SceneManager.GetActiveScene());
            Resources.UnloadUnusedAssets();
            Destroy(game);
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }

        // Update is called once per frame
        void Update() {
            
        }
    }
}
