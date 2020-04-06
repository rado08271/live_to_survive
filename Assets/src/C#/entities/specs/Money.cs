using System.Collections;
using System.Collections.Generic;

namespace eu.parada.entities.specs {
    public class Money {
        public double currentMoney { get; private set; }

        public Money(double currentMoney) {
            this.currentMoney = currentMoney;
        }

        public bool butStuff(int price) {
            if (currentMoney - price < 0) {
                return false;
            }
            currentMoney -= price;
            return true;
        }

        public bool butStuff(double price) {
            return butStuff((int)price);
        }


        public void earnMoney(int earned) {
            currentMoney += earned;
        }
    }
}
