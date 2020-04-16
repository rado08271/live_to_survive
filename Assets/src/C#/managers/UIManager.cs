using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using eu.parada.entities.events;
using eu.parada.enums;

namespace eu.parada.manager {
    public class UIManager : MonoBehaviour {
        public Game game;

        public Text healthValue;
        public Slider healthSlider;

        public Text energyValue;
        public Slider energySlider;

        public Text cellsCount;
        public Text virusCount;
        public Text immunityCount;

        public Text moneyValue;

        public Text dayCount;
        public Image dayTimeIcon;

        public Text userName;
        public Text userScore;

        public Button firstEffect;
        public Button secondEffect;
        public Button thirdEffect;
        public Button fourthEffect;
        public Button fifthEffect;

        


        // Update is called once per frame
        void Update() {
            if (game.isLoaded()) {
                healthValue.text = game.getHealth().ToString() + "%";
                //healthSlider.value = game.getHealth()/100;
                //healthSlider.value = 0.42f;// game.getHealth()/100;
                healthSlider.value = game.getHealth() / 100.00f;

                energyValue.text = game.getEnergy().ToString() + "%";
                energySlider.value = game.getEnergy() / 100.00f;

                cellsCount.text = game.getUserCells().ToString();
                virusCount.text = game.getUserViruses().ToString();
                immunityCount.text = game.getUserImmunity().ToString();

                moneyValue.text = game.getDna().ToString() + "$";

                dayCount.text = game.getCurrentDay().ToString() + "/" + game.getMaxDays().ToString();
                //dayCount.text = game.getDay().ToString();
                updateDay();

                userName.text = game.getUserName().ToString();
                userScore.text = game.getUserScore().ToString();

                checkEffect(0, firstEffect);
                checkEffect(1, secondEffect);
                checkEffect(2, thirdEffect);
                checkEffect(3, fourthEffect);
                checkEffect(4, fifthEffect);
            }
        }

        private void checkEffect(int i, Button effect) {
            int currentMoney = game.getDna();

            if (!PositiveEffects.getEffecByIndex(i).isActive) {
                if (currentMoney > PositiveEffects.getEffectList()[i].dnaPrice) {
                    effect.interactable = true;
                } else {
                    //effect.interactable = false;
                   
                }
            } else {
                //effect.interactable = false;
            }
        }

        private void updateDay() {
            if ( game.getCurrentDayTime() == DayTime.MORNING) {
                dayTimeIcon.color = Color.red;
            } else if (game.getCurrentDayTime() == DayTime.NOON) {
                dayTimeIcon.color = Color.yellow;
            } else if (game.getCurrentDayTime() == DayTime.EVENING) {
                dayTimeIcon.color = Color.green;
            } else if (game.getCurrentDayTime() == DayTime.SLEEP) {
                dayTimeIcon.color = Color.black;
            }
        }
    }
}
