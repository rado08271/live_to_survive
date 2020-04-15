using System.Collections;
using System.Collections.Generic;
using eu.parada.common;
using eu.parada.enums;

namespace eu.parada.entities.placeable {
    public class Virus : Organism, Spreadable<Virus> {

        public Virus() : base(Constants.HARMNESS_FOR_VIRUS, HarmnesType.NEGATIVE) {
        }

        public static int getVirusCountBasedOnDifficulty(int difficulty) {
            return ((difficulty * Constants.LUNGS_CELL_CAPACITY) / 100)/ Constants.VIRUS_DIFFICULTY_CONSTANT;
        }

        public IList<Virus> getRandomKids(int max) {
            max = Constants.MAXIMUM_SPREADING_KIDS - max;

            IList<Virus> kids = new List<Virus>();
            if (max > Constants.STARTING_SPREADING_VIRUS) max = Constants.STARTING_SPREADING_VIRUS;
            if (max < 1) max = 1;

            int randomNumber = Randomizer.getRandomNumberMax(max);
            for (int i = 0; i < randomNumber; i++) {
                kids.Add(new Virus());
            }

            return kids;
        }

        public double getHarmnessLevel() {
            //return ((int)base.harmness) * constant;
            return ((int) -1) * constant;
        }
    }

}
