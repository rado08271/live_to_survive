using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using eu.parada.manager;

namespace eu.parada {
    public class Difficulty : MonoBehaviour {
        public Text userNameText;
        public Button playButtonText;
        public Slider sliderDifficulty;
        private bool filledText = false;

        // Update is called once per frame
        void Update() {
            if (userNameText.text.Length > 0) {
                filledText = true;
                playButtonText.interactable = true;
            } else {
                filledText = false;
                playButtonText.interactable = false;
            }
        }

        public void playGame() {
            if (filledText) {
                Manager.getInstance().initNewGame(userNameText.text.ToString(), sliderDifficulty.value);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
            }
        }

        public void back() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
