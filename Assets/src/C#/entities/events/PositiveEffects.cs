using System;
using System.Collections.Generic;
using System.Text;
using eu.parada.common;

namespace eu.parada.entities.events {
    public class PositiveEffects {
        private static List<Effect> effectList = new List<Effect>() {
                (new Effect(StringConstant.LEARNING_TITLE, new List<string>(new string[] {StringConstant.LEARNING_TEXT_1, StringConstant.LEARNING_TEXT_2, StringConstant.LEARNING_TEXT_3 }), Constants.PRICE_FOR_LEARNING, 5, 0, 2)),
                (new Effect(StringConstant.WASHING_HANDS_TITLE, new List<string>(new string[] {StringConstant.WASHING_HANDS_TEXT_1, StringConstant.WASHING_HANDS_TEXT_2, StringConstant.WASHING_HANDS_TEXT_3}), Constants.PRICE_FOR_WASHING_HANDS, 10, 5, 5)),
                (new Effect(StringConstant.WEARING_PROTECTION_TITLE, new List<string>(new string[] {StringConstant.WEARING_PROTECTION_TEXT_1, StringConstant.WEARING_PROTECTION_TEXT_2, StringConstant.WEARING_PROTECTION_TEXT_3}), Constants.PRICE_FOR_WEARING_PROTECTION, 15, 7, 12)),
                (new Effect(StringConstant.SOCIAL_DISTANCING_TITLE, new List<string>(new string[] {StringConstant.SOCIAL_DISTANCING_TEXT_1, StringConstant.SOCIAL_DISTANCING_TEXT_2, StringConstant.SOCIAL_DISTANCING_TEXT_3 }), Constants.PRICE_FOR_SOCIAL_DISTANCING, 25, 10, 17)),
                (new Effect(StringConstant.HEALTHY_REGIME_TITLE, new List<string>(new string[] {StringConstant.HEALTHY_REGIME_TEXT_1, StringConstant.HEALTHY_REGIME_TEXT_2, StringConstant.HEALTHY_REGIME_TEXT_3 }), Constants.PRICE_FOR_HEALTHY_REGIMEN, 45, 20, 20))
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
            if (!effectList.Contains(effect) && effect.isActive) {
                return false;
            }

            effect.isActive = true;
            return effect.isActive;
        }

        public static void loseEffects() {
            foreach (var effect in effectList) {
                effect.isActive = false;
            }
        }
    }
}