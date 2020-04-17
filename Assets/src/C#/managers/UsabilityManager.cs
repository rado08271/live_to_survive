using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using eu.parada.common;
using eu.parada.generator;

namespace eu.parada.manager {
    public class UsabilityManager : MonoBehaviour {
        public Game game;

        public Text sumOfImmuityToBuyText;
        public Button increaseImmunityButton;

        public Generate cellGenerator;
        public Generate immunityGenerator;
        public Generate virusGenerator;

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

            // TODO: WTF...Delete pls
            cellGenerator.newInit(game.getUserCells());
            virusGenerator.newInit(game.getUserViruses());
            immunityGenerator.newInit(game.getUserImmunity());
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

            // TODO: WTF...Delete pls
            cellGenerator.newInit(game.getUserCells());
            virusGenerator.newInit(game.getUserViruses());
            immunityGenerator.newInit(game.getUserImmunity());
        }

        public void skipTurn() {
            game.nextTurn();

            // TODO: WTF...Delete pls
            cellGenerator.newInit(game.getUserCells());
            virusGenerator.newInit(game.getUserViruses());
            immunityGenerator.newInit(game.getUserImmunity());
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