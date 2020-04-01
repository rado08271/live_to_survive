package eu.rafig.covid.core.game.entities.placeable;

import eu.rafig.covid.core.game.common.Constants;
import eu.rafig.covid.core.game.common.Randomizer;

import java.util.ArrayList;
import java.util.List;

public class Imunity extends Organism implements Spreadable<Imunity> {

    public Imunity() {
        super(1.1, Harmness.POSITIVE);
    }

    @Override
    public List<Imunity> getRandomKids(int max) {
        List<Imunity> kids = new ArrayList<>();
        if (max > Constants.MAXIMUM_SPREADING_KIDS) max = Constants.MAXIMUM_SPREADING_KIDS;
        if (max <= 0) max = 1;

        int randomNumber = Randomizer.getRandomNumberMax(max);
        for (int i = 0; i < randomNumber; i++) {
            kids.add(new Imunity());
        }

        return kids;
    }

    @Override
    public double getHarmnessLevel() {
        return super.getHarmness().getHarmness() * getConstant();
    }
}
