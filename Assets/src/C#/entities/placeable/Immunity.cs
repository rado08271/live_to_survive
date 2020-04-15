using System.Collections;
using System.Collections.Generic;
using eu.parada.common;
using eu.parada.enums;

namespace eu.parada.entities.placeable {
    public class Immunity : Organism, Spreadable<Immunity> {

        public Immunity() : base(Constants.HARMNESS_FOR_IMUNITY, HarmnesType.POSITIVE) {
        }

        public IList<Immunity> getRandomKids(int max) {
            IList<Immunity> kids = new List<Immunity>();
            if (max > Constants.MAXIMUM_SPREADING_KIDS) max = Constants.MAXIMUM_SPREADING_KIDS;
            if (max <= Constants.STARTING_SPREADING_IMMUNITY) max = Constants.STARTING_SPREADING_IMMUNITY;

            int randomNumber = Randomizer.getRandomNumberMax(max);
            for (int i = 0; i < randomNumber; i++) {
                kids.Add(new Immunity());
            }

            return kids;
        }

        public double getHarmnessLevel() {
            return ((int) base.harmness) * constant;
        }

    }
}
