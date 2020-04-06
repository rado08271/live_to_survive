using System.Collections;
using System.Collections.Generic;

namespace eu.parada.common {
	public class DayCounter {
        public static int dayCount { get; private set; }

        public static int increaseDay() {
            return dayCount++;
        }
    }
}