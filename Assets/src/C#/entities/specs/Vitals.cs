using System.Collections;
using System.Collections.Generic;
using eu.parada.common;

namespace eu.parada.entities.specs {
    public class Vitals {
        public Health health { get; private set; }
        public Energy energy { get; private set; }
        public Money money { get; private set; }

        public Vitals() {
            health = new Health(Constants.STARTING_HEALTH);
            money = new Money(Constants.STARTING_MONEY);
            energy = new Energy(Constants.STARTING_ENERGY);
        }
        public Vitals(int difficulty) {
            health = new Health(Constants.STARTING_HEALTH - (difficulty/ Constants.VITALS_DIFFICULTY_CONSTANT));
            energy = new Energy(Constants.STARTING_ENERGY - (difficulty/ Constants.VITALS_DIFFICULTY_CONSTANT));
            money = new Money(Constants.STARTING_MONEY);
        }
    }
}
