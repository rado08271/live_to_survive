using System.Collections;
using System.Collections.Generic;

namespace eu.parada.entities.events {
    public class Effect {
        //TODO: if effects are more complex then redefine each effect
        public string desciption { get; private set; }
        public bool isActive { get; set; }
        public double dnaPrice { get; private set; }
        public double spreadingRate{ get; private set; }
        public double energyRate { get; private set; }
        public double reprodutctionRate { get; private set; }
        public Effect(string desciption, double dnaPrice) {
            this.desciption = desciption;
            this.isActive = false;
            this.dnaPrice = dnaPrice;
        }

        public Effect (string desciption, double dnaPrice, double spreading, double energy, double reproduction) {
            this.desciption = desciption;
            this.dnaPrice = dnaPrice;
            this.isActive = false;
            this.spreadingRate = spreading;
            this.energyRate = energy;
            this.reprodutctionRate = reproduction;
        }

    }
}
