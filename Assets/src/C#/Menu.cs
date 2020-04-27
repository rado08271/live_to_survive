using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using eu.parada.manager;

namespace eu.parada {
    public class Menu : MonoBehaviour {

        public GameObject resumeGamePanel;
        private bool started = false;

        public void playGame() {
            if (resumeGamePanel != null) {
                if (!started && Manager.getInstance().getGamePlay() != null) {
                    resumeGamePanel.SetActive(true);
                    started = true;
                } else {
                    resumeGamePanel.SetActive(false);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }

        public void quitGame() {
            Application.Quit();
        }

        public void resumeGame() {
            StartCoroutine(continueGame());
        }

        public void settings() {
            SceneManager.LoadScene(4, LoadSceneMode.Single);
        }

        private IEnumerator continueGame() {
            //Destroy(this);
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2, LoadSceneMode.Single);
        }
    }
}