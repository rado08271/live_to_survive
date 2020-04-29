using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using eu.parada.common;
using eu.parada.entities.placeable;

namespace eu.parada.manager {
    public class DifficultyUIManager : MonoBehaviour {
        public Text difficulty;
        public Text startingHealth;
        public Text startingEnergy;
        public Text startingVirus;
        public Text daysToWinGame;
        public Text scoreBonus;

        public Slider slider;


        // Update is called once per frame
        void Update() {
            int sliderDiff = (int)(slider.value * 100);
            
            // Use this for initialization
            difficulty.text = "OVERALL DIFFICULTY: " + (sliderDiff).ToString();
            startingHealth.text = "STARTING HEALTH: " + (100 - (sliderDiff/ Constants.VITALS_DIFFICULTY_CONSTANT)).ToString();
            startingEnergy.text = "STARTING ENERGY: " + (100 - (sliderDiff/ Constants.VITALS_DIFFICULTY_CONSTANT)).ToString();
            startingVirus.text = "STARTING VIRUS: " + (Virus.getVirusCountBasedOnDifficulty(sliderDiff)).ToString();
            daysToWinGame.text = "DAYS TO WIN GAME: " + (DayCounter.maxDaysInit(sliderDiff).ToString());
            scoreBonus.text = "SCORE BONUS: " + (slider.value).ToString();
        }
    }
}
