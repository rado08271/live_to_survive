using System;
using System.Collections.Generic;
using System.Text;
using eu.parada.common;

namespace eu.parada.entities.events {
    public class PositiveEffects {
        private static List<Effect> effectList = new List<Effect>() {
                (new Effect("Learning", Constants.PRICE_FOR_LEARNING, 5, 0, 2)),
                (new Effect("Washing hands", Constants.PRICE_FOR_WASHING_HANDS, 10, 5, 5)),
                (new Effect("Wearing protection", Constants.PRICE_FOR_WEARING_PROTECTION, 15, 7, 12)),
                (new Effect("Social Distancing", Constants.PRICE_FOR_SOCIAL_DISTANCING, 25, 10, 17)),
                (new Effect("Healthy regime", Constants.PRICE_FOR_HEALTHY_REGIMEN, 45, 20, 20))
            };

        public static List<Effect> getEffectList() {
                return effectList;
        }

        public static Effect getEffecByIndex (int index) {
            if (index > getEffectList().Count) return null;
            return getEffectList()[index];
        }

        public static int bonus {
            get {
                int bonus = 0;
                foreach (Effect e in effectList) {
                    if (e.isActive) bonus++;
                }
                return bonus;
            }
        }

        public static bool buyEffect(Effect effect) {
            if (!effectList.Contains(effect)) {
                StringUtils.getInstance().addMessage("Sorry there is no such effect");
                return false;
            }

            effect.isActive = true;
            return effect.isActive;
        }

    }
}