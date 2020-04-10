package eu.rafig.covid.core.game.entities.placeable;

import eu.rafig.covid.core.game.common.Constants;
import eu.rafig.covid.core.game.common.Randomizer;

import java.util.ArrayList;
import java.util.List;

public class Virus extends Organism implements Spreadable<Virus> {

    public Virus() {
        super(Constants.HARMNESS_FOR_VIRUS, Harmness.NEGATIVE);
    }

    @Override
    public List<Virus> getRandomKids(int max) {
        max = Constants.MAXIMUM_SPREADING_KIDS - max;

        List<Virus> kids = new ArrayList<>();
        if (max > Constants.STARTING_SPREADING_VIRUS) max = Constants.STARTING_SPREADING_VIRUS;
        if (max <= 1) max = 1;

        int randomNumber = Randomizer.getRandomNumberMax(max);
        for (int i = 0; i < randomNumber; i++) {
            kids.add(new Virus());
        }

        return kids;
    }

    @Override
    public double getHarmnessLevel() {
        return super.getHarmness().getHarmness() * getConstant();
    }
}
