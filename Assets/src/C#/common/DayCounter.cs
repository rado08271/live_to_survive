using System.Collections;
using System.Collections.Generic;

namespace eu.parada.common {
	public class DayCounter {
        public int dayCount { get; private set; }
        private int maxDays;

        public DayCounter() {
            this.dayCount = 0;
        }

        public DayCounter(int difficulty) {
            this.dayCount = 0;

            this.maxDays = maxDaysInit(difficulty);
        }

        public static int maxDaysInit(int difficulty) {
            int percentage = 100 - difficulty;

            int daysOfPercentage = (percentage * (Constants.MAX_GAME_LENGTH - Constants.MIN_GAME_LENGTH)) / 100;

            return Constants.MIN_GAME_LENGTH + daysOfPercentage;
        }

        public int increaseDay() {
            return dayCount++;
        }

        public int getMaxDays() {
            return this.maxDays;
        }
    }
}