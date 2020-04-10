package eu.rafig.covid.core.game.entities.effects;

import eu.rafig.covid.core.game.common.Constants;

import java.util.Arrays;
import java.util.List;

public class PositiveEffects {
    private static List<Effect> effectList = Arrays.asList(
        (new Effect("Learning", Constants.PRICE_FOR_LEARNING, 5, 0,2)),
        (new Effect("Washing hands", Constants.PRICE_FOR_WASHING_HANDS,10 ,5,5)),
        (new Effect("Wearing protection", Constants.PRICE_FOR_WEARING_PROTECTION, 15, 7,12)),
        (new Effect("Social Distancing", Constants.PRICE_FOR_SOCIAL_DISTANCING, 25, 10,17)),
        (new Effect("Healthy regime", Constants.PRICE_FOR_HEALTHY_REGIMEN, 45,20,20))

    );

    public static List<Effect> getEffectList() {
        return effectList;
    }

    public static int getBonus() {
        int bonus = 0;
        for (Effect e :effectList) {
            if (e.isActive()) bonus++;
        }
        return bonus;
    }

    public static boolean buyEffect(Effect effect) {
        if (!effectList.contains(effect)) {
            return false;
        }

        effect.setActive(true);
        return effect.isActive();
    }
}
