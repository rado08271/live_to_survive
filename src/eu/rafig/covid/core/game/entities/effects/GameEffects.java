package eu.rafig.covid.core.game.entities.effects;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class GameEffects {
    private static List<Effect> effectList = Arrays.asList(
        (new Effect("Washing hands", 20)),
        (new Effect("Wearing protection", 20)),
        (new Effect("Social Distancing", 20)),
        (new Effect("Healthy regime", 20)),
        (new Effect("Learning", 20))
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
