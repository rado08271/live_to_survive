using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using eu.parada.common;

namespace eu.parada.manager {
    public class UsabilityManager : MonoBehaviour {
        public Game game;
        public Text sumOfImmuityToBuyText;
        public Button increaseImmunityButton;
        public MessaggingManager messaggingManager;

        private int immunitiesToBuy = 0;

        public void increaseValue() {
            immunitiesToBuy++;
        }

        public void maxIncrease() {
            immunitiesToBuy = game.getDna();
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
            if(!game.buyEffects(4))
                messaggingManager.ShowMessagge("ahoj");
        }

        public void attack() {
            game.fight();
        }

        public void skipTurn() {
            game.nextTurn();
        }

        void Update() {
            if (game.isLoaded()) {
                if (game.getDna() <= immunitiesToBuy) {
                    increaseImmunityButton.interactable = false;
                } else {
                    increaseImmunityButton.interactable = true;

                }
                sumOfImmuityToBuyText.text = immunitiesToBuy.ToString();

            }
        }
    }
}