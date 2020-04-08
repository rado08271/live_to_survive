using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace eu.parada {
    public class Menu : MonoBehaviour {

        public void playGame() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void quitGame() {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}