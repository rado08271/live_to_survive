using System.Collections;
using System.Collections.Generic;
using eu.parada.common;
using eu.parada.enums;

namespace eu.parada.entities.placeable {
    public class Virus : Organism, Spreadable<Virus> {

        public Virus() : base(Constants.HARMNESS_FOR_VIRUS, HarmnesType.NEGATIVE) {
        }

        public IList<Virus> getRandomKids(int max) {
            max = Constants.MAXIMUM_SPREADING_KIDS - max;

            IList<Virus> kids = new List<Virus>();
            if (max > Constants.STARTING_SPREADING_VIRUS) {
                max = Constants.STARTING_SPREADING_VIRUS;
            }
            if (max < 0) {
                max = 0;
            }

            int randomNumber = Randomizer.getRandomNumberMax(max);
            for (int i = 0; i < randomNumber; i++) {
                kids.Add(new Virus());
            }

            return kids;
        }

        public double getHarmnessLevel() {
            return (double) base.harmness * constant;
        }
    }

}
