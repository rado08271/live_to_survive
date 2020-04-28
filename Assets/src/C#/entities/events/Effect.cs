using System.Collections;
using System.Collections.Generic;
using eu.parada.common;

namespace eu.parada.entities.events {
    public class Effect {
        //TODO: if effects are more complex then redefine each effect
        public string desciption { get; private set; }
        public bool isActive { get; set; }
        public double dnaPrice { get; private set; }
        public double spreadingRate{ get; private set; }
        public double energyRate { get; private set; }
        public double reprodutctionRate { get; private set; }

        private List<string> messages;

        public Effect(string desciption, List<string> messages, double dnaPrice) {
            this.desciption = desciption;
            this.isActive = false;
            this.dnaPrice = dnaPrice;
            this.messages = messages;
        }

        public Effect (string desciption, List<string> messages, double dnaPrice, double spreading, double energy, double reproduction) {
            this.desciption = desciption;
            this.dnaPrice = dnaPrice;
            this.isActive = false;
            this.spreadingRate = spreading;
            this.energyRate = energy;
            this.reprodutctionRate = reproduction;
            this.messages = messages;
        }

        public StringMessage getRandomMessage() {
            string randomString = messages[Randomizer.getRandomNumberMax(messages.Count - 1)];
            StringMessage message = new StringMessage(randomString, desciption);
            message.setLoggable(true);
            return message;
        }

    }
}
