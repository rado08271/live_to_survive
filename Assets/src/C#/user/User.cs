using System;
using System.Collections.Generic;
using System.Text;

namespace eu.parada.user {
    public class User {
        public string name { get; private set; }
        public double score  { get; private set; }

        private double difficulty = 0;

        public User(string name, double difficulty) {
            this.name = name;
            this.score = 0;
            this.difficulty = difficulty;
        }

        public User(string name) {
            this.name = name;
            this.score = 0;
        }

        public double addScore(double score) {
            if ( score > 0) {
                this.score += (score + ((int) score * difficulty));
            }

            return this.score;
        }
    }
}

