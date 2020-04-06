using System.Collections;
using System.Collections.Generic;
using eu.parada.enums;

namespace eu.parada.entities.placeable {
    public abstract class Organism {
        public double constant { get; private set; }
        public string name { get; private set; }
        public HarmnesType harmness { get; private set; }

        public Organism(double constant, HarmnesType harmness) {
            this.constant = constant;
            this.harmness = harmness;
        }

        public Organism(double constant, string name) {
            this.constant = constant;
            this.name = name;
        }

        public Organism(double constant) {
            this.constant = constant;
        }
    }
}
