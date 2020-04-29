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
        private DayCounter dayCounter;
        private bool onboarding = false;


        public GamePlay(string userName, double difficulty) {
            this.user = new User(userName, difficulty);
            this.gameState = GameState.PLAYING;
            this.lungs = new Lungs(Constants.LUNGS_CELL_CAPACITY, "Lungs", (int) (difficulty * 100));
            this.events = new Events(lungs);
            this.dayCounter = new DayCounter((int) (difficulty*100));
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

            if (dayCounter.dayCount >= dayCounter.getMaxDays()) {
                gameState = GameState.NOTIME;
            }

            return (gameState == GameState.PLAYING) ? true : false;
        }

        public bool buy(int choice) {
            if (choice >= PositiveEffects.getEffectList().Count) return false;
            return lungs.buyEffect(PositiveEffects.getEffecByIndex(choice));
        }

        public virtual bool buySomeImmunity(int count) {
            if (count == 0) return false;
            return events.buyImmunity(count);
        }

        public virtual bool attack() {
            int score = lungs.fight();
            user.addScore(score);
            return (lungs.dayTime == DayTime.SLEEP && score <= 0 ) ? false : true;
        }

        public virtual double changedHealth() {
            return lungs.getHealthToChange();
        }

        public int getCurrentDay() {
            return dayCounter.dayCount;
        }

        public int getMaxDays() {
            return dayCounter.getMaxDays();
        }

        private int nextDay() {
            user.addScore(1);
            return dayCounter.increaseDay();
        }

        /////////////////////////////////// !!! UTILITARIAN AND UI NOT IMPORTANT !!! //////////////////////////////////////////////
        private List<StringMessage> messages = new List<StringMessage>() {
            new StringMessage(StringConstant.FACT_1_TEXT, StringConstant.FACT_1_TITLE),
            new StringMessage(StringConstant.FACT_2_TEXT, StringConstant.FACT_2_TITLE),
            new StringMessage(StringConstant.FACT_3_TEXT, StringConstant.FACT_3_TITLE),
            new StringMessage(StringConstant.FACT_4_TEXT, StringConstant.FACT_4_TITLE),
            new StringMessage(StringConstant.FACT_5_TEXT, StringConstant.FACT_5_TITLE),
            new StringMessage(StringConstant.FACT_6_TEXT, StringConstant.FACT_6_TITLE),
            new StringMessage(StringConstant.FACT_7_TEXT, StringConstant.FACT_7_TITLE),
            new StringMessage(StringConstant.FACT_8_TEXT, StringConstant.FACT_8_TITLE),
            new StringMessage(StringConstant.FACT_9_TEXT, StringConstant.FACT_9_TITLE),
            new StringMessage(StringConstant.FACT_10_TEXT, StringConstant.FACT_10_TITLE),
            new StringMessage(StringConstant.FACT_11_TEXT, StringConstant.FACT_11_TITLE),
            new StringMessage(StringConstant.FACT_12_TEXT, StringConstant.FACT_12_TITLE),
            new StringMessage(StringConstant.FACT_13_TEXT, StringConstant.FACT_13_TITLE),
            new StringMessage(StringConstant.FACT_14_TEXT, StringConstant.FACT_14_TITLE),
            new StringMessage(StringConstant.FACT_15_TEXT, StringConstant.FACT_15_TITLE),
            new StringMessage(StringConstant.FACT_16_TEXT, StringConstant.FACT_16_TITLE)
        };

        public StringMessage getFact(int factNumber) {
            if (factNumber < 0 || factNumber >= messages.Count) return null;

            return messages[factNumber];
            
        }

        public void showInitialScreen() {
            onboarding = true;
        }

        public bool seenInitialScreen() {
            return onboarding;
        }
    }
}
