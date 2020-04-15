using System.Collections;
using System.Collections.Generic;
using eu.parada.common;
using eu.parada.entities.organ;
using eu.parada.entities.placeable;

namespace eu.parada.entities.events {
    public class Events {
        private Lungs lungs;

        public Events(Lungs lungs) {
            this.lungs = lungs;
        }

        public void addVirus() {
            int maxViruses = PositiveEffects.getEffectList().Count - PositiveEffects.bonus;
            int numberOfViruses = Randomizer.getRandomNumberMax(maxViruses);

            for (int i = 0; i < numberOfViruses; i++) {
                lungs.addVirus();
            }
        }

        public bool buyImmunity(int count) {
            IList<Immunity> imunitiesToBuy = (new ListFilter<Immunity>()).fillList(new Immunity(), count);
            return lungs.addImmunities(imunitiesToBuy);
        }
    }
}
