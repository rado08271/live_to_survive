using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using eu.parada.common;

namespace eu.parada.manager {
    public class UsabilityManager : MonoBehaviour {
        public Game game;

        public Text sumOfImmuityToBuyText;
        public Button sumOfImmuityToBuyButton;

        private int immunitiesToBuy = 0;

        public void increaseValue() {
            immunitiesToBuy++;
        }

        public void decreaseValue() {
            immunitiesToBuy--;
            if (immunitiesToBuy < 0) immunitiesToBuy = 0;
        }

        public void buyImmunity () {
            if (game.buyImmunity(immunitiesToBuy))
                immunitiesToBuy = 0;
        }

        public void buyFirstEffect() {
            game.buyEffects(0);
        }

        public void buySecondEffect() {
            game.buyEffects(1);
        }

        public void buyThirdEffect() {
            game.buyEffects(2);
        }

        public void buyFourthEffect() {
            game.buyEffects(3);
        }

        public void buyFifthEffect() {
            game.buyEffects(4);
        }

        public void attack() {
            game.fight();
        }

        public void skipTurn() {
            game.nextTurn();
        }

        void Update() {
            if (game.getDna() < immunitiesToBuy) {
                sumOfImmuityToBuyButton.interactable = false;
            } else {
                sumOfImmuityToBuyButton.interactable = true;

            }
            sumOfImmuityToBuyText.text = immunitiesToBuy.ToString();

        }
    }
}