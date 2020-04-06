using System.Collections;
using System.Collections.Generic;
using eu.parada.common;
using eu.parada.enums;

namespace eu.parada.entities.placeable {
    public class Cell : Organism {

        public Cell() : base(Constants.HARMNESS_FOR_CELL, HarmnesType.NEUTRAL) {
        }
    }
}
