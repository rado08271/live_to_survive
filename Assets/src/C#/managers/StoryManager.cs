using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using eu.parada.common;

namespace eu.parada.manager {
    public class StoryManager : MonoBehaviour {

        public Image lungs;
        public Game game;

        public bool welcome = true;

        void Update() {
            showDialogue();
            float value = (game.getUserViruses() * 1.0f / game.getUserCells() * 1.0f); 
            if (value > 0 && value <= 1.0f) {
                lungs.color = new Color(lungs.color.r, lungs.color.g, lungs.color.b, 1.0f - value); ;
            }
        }

        private void showDialogue() {
            if (!game.seenInitialScreen()) {
                string username = game.getUserName();

                StringUtils.getInstance().addMessage(new StringMessage(StringConstant.WELCOME_TEXT_MESSAGE, username + StringConstant.WELCOM_TITLE_MESSAGE));

                welcome = false;

                game.showInitScreen();
            }
        }
        
    }
}