using System.Collections;
using System.Collections.Generic;
using eu.parada.common;

namespace eu.parada.entities.specs {
    public class Energy {
        public double currentEnergy { get; private set; } 

        public Energy() {
            this.currentEnergy = Constants.MAX_HEALTH;
        }

        public Energy(double currentEnergy) {
            this.currentEnergy = currentEnergy;
        }

        public double getEnergy() {
            return currentEnergy;
        }

        public bool decreaseEnergy(double value) {
            if (currentEnergy - value < 0) {
                currentEnergy = 0;
                return false;
            }
            currentEnergy -= value;
            return true;
        }

        public bool increaseEnergy(double value) {
            if (value + currentEnergy > Constants.MAX_HEALTH) {
                currentEnergy = Constants.MAX_HEALTH;
                return false;
            }
            currentEnergy += value;
            return true;
        }
    }
}
