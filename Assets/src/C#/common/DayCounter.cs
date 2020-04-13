using System.Collections;
using System.Collections.Generic;

namespace eu.parada.common {
	public class DayCounter {
        public int dayCount { get; private set; }

        public DayCounter() {
            this.dayCount = 0;
        }

        public int increaseDay() {
            return dayCount++;
        }
    }
}