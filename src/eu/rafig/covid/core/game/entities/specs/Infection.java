package eu.rafig.covid.core.game.entities.specs;

import eu.rafig.covid.core.game.entities.effects.Effect;
import eu.rafig.covid.core.game.entities.effects.NegativeEffects;

import java.util.List;

public class Infection {
    private int mutationTies = 0;
    private Money currentMoney = new Money();
    private List<Effect> infectionEffects;

    public boolean increaseMutationLevel() {
        // TODO: Do nothing
        if (mutationTies == 0) return false;



        if (mutationTies >= 4) return false;
        if (mutationTies != 0) mutationTies++;
        if (!currentMoney.butStuff(NegativeEffects.getEffectList().get(mutationTies).getDnaPrice())) return false;
        if (infectionEffects.contains(NegativeEffects.getEffectList().get(mutationTies))) return false;

        infectionEffects.add(NegativeEffects.getEffectList().get(mutationTies));

        return true;
    }

    public Money getCurrentRNA() {
        return currentMoney;
    }
}
