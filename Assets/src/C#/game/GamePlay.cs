using System.Collections;
using System.Collections.Generic;
using eu.parada.entities.organ;
using eu.parada.entities.events;
using eu.parada.user;
using eu.parada.enums;
using eu.parada.common;

namespace eu.parada.game {
	public class GamePlay {
        public User user { get; private set; }
        public GameState gameState { get; private set; }
        public Lungs lungs { get; private set; }
        private Events events;
        private DayCounter dayCounter = new DayCounter();

        public GamePlay(string userName, double difficulty) {
            this.user = new User(userName, difficulty);
            this.gameState = GameState.PLAYING;
            this.lungs = new Lungs(Constants.LUNGS_CELL_CAPACITY, "Lungs", (int) (difficulty * 100));
            this.events = new Events(lungs);
        }

        public virtual bool newDay() {
            nextDay();

            // TODO: Maybe add higher randomness?
            events.addVirus();

            lungs.endDay();

            if (lungs.lungsState == LungsState.CURED) {
                gameState = GameState.WON;
            }

            if (lungs.lungsState == LungsState.DESTROYED) {
                gameState = GameState.FAILED;
            }

            if (dayCounter.dayCount >= Constants.GAME_LENGTH) {
                gameState = GameState.NOTIME;
            }

            return (gameState == GameState.PLAYING) ? true : false;
        }

        public bool buy(int choice) {
            if (choice >= PositiveEffects.getEffectList.Capacity) {
                return false;
            }

            return lungs.buyEffect(PositiveEffects.getEffecByIndex(choice));
        }

        public virtual bool buySomeImmunity(int count) {
            return events.buyImmunity(count);
        }

        public virtual bool attack() {
            user.addScore(lungs.fight());
            return (lungs.dayTime == DayTime.SLEEP) ? false : true;
        }

        public int getCurrentDay() {
            return dayCounter.dayCount;
        }

        private int nextDay() {
            user.addScore(1);
            return dayCounter.increaseDay();
        }
    }
}
