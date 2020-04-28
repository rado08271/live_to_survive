using System.Collections;
using System.Collections.Generic;
using eu.parada.common;

namespace eu.parada.entities.events {
    public class NegativeEffects {
        private static List<Effect> effectList = new List<Effect>() {
            (new Effect("Meeting a friend", null, Constants.PRICE_FOR_WASHING_HANDS)),
            (new Effect("Shopping", null, Constants.PRICE_FOR_WEARING_PROTECTION)),
            (new Effect("Going for a drink", null, Constants.PRICE_FOR_SOCIAL_DISTANCING)),
            (new Effect("Traveling the world", null, Constants.PRICE_FOR_HEALTHY_REGIMEN)),
            (new Effect("Pizza, pasta", null, Constants.PRICE_FOR_LEARNING))
        };

        public static List<Effect> getEffectList {
            get {
                return effectList;
            }
        }

        public static int bonus {
            get {
                int bonus = 0;
                foreach (Effect e in effectList) {
                    if (e.isActive) {
                        bonus++;
                    }
                }
                return bonus;
            }
        }

        public static bool buyEffect(Effect effect) {
            if (!effectList.Contains(effect)) {
                return false;
            }

            effect.isActive = true;
            return effect.isActive;
        }
    }
}
