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

        public Text priceForDna;

        private int immunitiesToBuy = 0;

        public void increaseValue() {
            immunitiesToBuy++;
        }

        public void maxIncrease() {
            immunitiesToBuy = (int) (game.getDna());
        }

        public void decreaseValue() {
            immunitiesToBuy--;
            if (immunitiesToBuy < 0) immunitiesToBuy = 0;
        }

        public void buyImmunity () {
            if (game.buyImmunity((int)(immunitiesToBuy * Constants.IMUNITY_PRICE)))
                immunitiesToBuy = 0;
        }

        public void buyFirstEffect() {
            game.getAudioChannel().playLearningSound();

            game.buyEffects(0);
        }

        public void buySecondEffect() {
            game.getAudioChannel().playWashingHandsSound();

            game.buyEffects(1);
        }

        public void buyThirdEffect() {
            game.getAudioChannel().playWearingFaceMaskSound();

            game.buyEffects(2);
        }

        public void buyFourthEffect() {
            game.getAudioChannel().playSocialDistancing();

            game.buyEffects(3);
        }

        public void buyFifthEffect() {
            game.getAudioChannel().playHealthyRegime();

            game.buyEffects(4);
        }

        public void attack() {
            game.fight();
        }

        public void skipTurn() {
            game.nextTurn();
            StringMessage msg = game.getRandomFact();
            StringUtils.getInstance().addMessage(msg);

        }

        void Update() {
            if (game.isLoaded()) {
                if (game.getDna() <= immunitiesToBuy) {
                    increaseImmunityButton.interactable = false;
                } else {
                    increaseImmunityButton.interactable = true;

                }
                sumOfImmuityToBuyText.text = ((int)(immunitiesToBuy * Constants.IMUNITY_PRICE)).ToString();
                priceForDna.text = immunitiesToBuy.ToString();
            }
        }
    }
}