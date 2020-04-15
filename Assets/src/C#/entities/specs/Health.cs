using System.Collections;
using System.Collections.Generic;
using eu.parada.common;

namespace eu.parada.entities.specs {
    public class Health {
        public double currentHealth { get; private set; }

        public Health(double currentHealth) {
            this.currentHealth = currentHealth;
        }

        public Health() {
            this.currentHealth = Constants.MAX_HEALTH;
        }

        public void applyChanges(double value) {
            if (value == 0) return;

            currentHealth -= value / Constants.HEALTH_DIVIDE_CONSTANT;
            if (currentHealth >= Constants.MAX_HEALTH) currentHealth = Constants.MAX_HEALTH;
            if (currentHealth <= 0) currentHealth = 0;
        }

    }
}
