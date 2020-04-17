using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using eu.parada.enums;

namespace eu.parada.manager {
    public class DayManager : MonoBehaviour {
        public Image dayTimeIcon;

        public Sprite morningIcon;
        public Sprite noonIcon;
        public Sprite eveningIcon;
        public Sprite sleepingIcon;

        public Game game;

        // Update is called once per frame
        void Update() {
            updateDay();
        }

        private void updateDay() {
            if (game.getCurrentDayTime() == DayTime.MORNING) {
                dayTimeIcon.sprite = morningIcon;
            } else if (game.getCurrentDayTime() == DayTime.NOON) {
                dayTimeIcon.sprite = noonIcon;
            } else if (game.getCurrentDayTime() == DayTime.EVENING) {
                dayTimeIcon.sprite = eveningIcon;
            } else if (game.getCurrentDayTime() == DayTime.SLEEP) {
                dayTimeIcon.sprite = sleepingIcon;
            }
        }
    }
}