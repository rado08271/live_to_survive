using System;
using System.Collections.Generic;
using System.Text;
using eu.parada.common;

namespace eu.parada.entities.events {
    public class PositiveEffects {
        private static List<Effect> effectList = new List<Effect>() {
                (new Effect("Washing hands", Constants.PRICE_FOR_WASHING_HANDS)),
                (new Effect("Wearing protection", Constants.PRICE_FOR_WEARING_PROTECTION)),
                (new Effect("Social Distancing", Constants.PRICE_FOR_SOCIAL_DISTANCING)),
                (new Effect("Healthy regime", Constants.PRICE_FOR_HEALTHY_REGIMEN)),
                (new Effect("Learning", Constants.PRICE_FOR_LEARNING))
            };

        public static List<Effect> getEffectList {
            get {
                return effectList;
            }
        }

        public static Effect getEffecByIndex (int index) {
            if (index > getEffectList.Count) return null;
            return getEffectList[index];
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