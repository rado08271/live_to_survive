using System.Collections;
using System;
using System.Collections.Generic;
using eu.parada.entities.specs;
using eu.parada.enums;
using eu.parada.entities.placeable;
using eu.parada.entities.events;
using eu.parada.common;

namespace eu.parada.entities.organ {
    public class Lungs {
        public Vitals vitals { get; private set; }
        public string description { get; private set; }
        public LungsState lungsState { get; private set; }
        public DayTime dayTime { get; private set; }
        public int time = 0;

        public IList<Virus> viruses { get; private set; }
        public IList<Immunity> imunities { get; private set; }
        public IList<Cell> cells { get; private set; }
        public IList<Effect> boughtEffects { get; private set; }

        public Lungs(int availableCells, string description, int difficulty) {
            this.description = description;
            this.vitals = new Vitals(difficulty);
            
            this.viruses = (new ListFilter<Virus>()).fillList(new Virus(), Virus.getVirusCountBasedOnDifficulty(difficulty));
            this.imunities = (new ListFilter<Immunity>()).fillList(new Immunity(), 0);
            this.cells = (new ListFilter<Cell>()).fillList(new Cell(), availableCells);
            this.boughtEffects = new List<Effect>();

            this.dayTime = DayTime.MORNING;

            // FIXME: this is for testing only!!!
            //this.vitals = new Vitals(96);
            //this.viruses = (new ListFilter<Virus>()).fillList(new Virus(), 10);
            //this.imunities = (new ListFilter<Immunity>()).fillList(new Immunity(), 6);

        }

        public int fight() {
            if (!increaseDay()) {
                //TODO: You are sleeping!
                return 0;
            }

            int virusesCount = (viruses.Count - imunities.Count) >= 0 ? (viruses.Count - imunities.Count) : 0;
            int imunitieCounts = (imunities.Count - viruses.Count) >= 0 ? (imunities.Count - viruses.Count) : 0;

            double tmpEnergy = vitals.energy.currentEnergy;
            // You do not have any energy
            if (!vitals.energy.decreaseEnergy(( imunities.Count - imunitieCounts) * Constants.ENERGY_FOR_ONE_CELL_FIGHT)) {
                imunitieCounts = imunities.Count - (int) tmpEnergy;
                virusesCount = viruses.Count - (int) tmpEnergy;
            }

            int virusesSize = viruses.Count;
            for (int i = virusesSize - 1; i >= virusesCount; i--) {
                viruses.RemoveAt(i);
            }

            int immunitiesSize = imunities.Count;
            for (int i = immunitiesSize - 1; i >= imunitieCounts; i--) {
                imunities.RemoveAt(i);
            }

            vitals.money.earnMoney((int)(immunitiesSize - imunities.Count * Constants.REWARD_FOR_FIGHT));
            StringUtils.getInstance().addMessage(new StringMessage("Your immunities killed " + (immunitiesSize - imunities.Count) + " viruses, but lost " + (tmpEnergy - vitals.energy.currentEnergy) + " energy in fight", true));

            return immunitiesSize - imunities.Count;
        }

        public bool buyEffect(Effect effect) {
            if (!vitals.money.butStuff(effect.dnaPrice)) return false;
            if (effect.isActive) return false;
            if (boughtEffects.Contains(effect)) return false;

            effect.isActive = true;
            boughtEffects.Add(effect);

            StringUtils.getInstance().addMessage(effect.getRandomMessage());

            return true;
        }

        // TODO: If you exceeded the caacity of immunity cells in your body than you will not ve able to get virus...
        // what about changing this?
        public bool addVirus() {
            // TODO: Decide whether could be infected when healthy and does not do what he should..not buying effects
            if (lungsState == LungsState.WORKING || lungsState == LungsState.CURED) {
                lungsState = LungsState.INFECTED;
            }

            if (viruses.Count + 1 >= cells.Count) return false;
            viruses.Add(new Virus());

            return true;
        }

        public virtual bool addImmunities(IList<Immunity> imumnityToAdd) {
            if (imunities.Count + imumnityToAdd.Count > cells.Count) return false;
            if (!vitals.money.butStuff(Math.Ceiling(imumnityToAdd.Count / Constants.IMUNITY_PRICE))) return false;

            StringUtils.getInstance().addMessage(new StringMessage("Your bought " + (imumnityToAdd.Count) + " immunities and payed " + Math.Ceiling(imumnityToAdd.Count / Constants.IMUNITY_PRICE) + " DNA", true));

            ((List<Immunity>) imunities).AddRange(imumnityToAdd);
            return true;
        }

        public virtual void endDay() {
            dayTime = DayTime.MORNING;
            time = 0;
            vitals.energy.increaseEnergy(Constants.ENERGY_FOR_ONE_SLEEP);
            hardLaborForImmunity();
            healthCheck(true);
            reproduction();

            if (viruses.Count == 0 && boughtEffects.Count == PositiveEffects.getEffectList().Count && lungsState == LungsState.INFECTED) {
                lungsState = LungsState.CURED;
            } else if (viruses.Count >= cells.Count || vitals.health.currentHealth <= 0) {
                lungsState = LungsState.DESTROYED;
            }
        }

        public int getKindaTime() {
            return time;
        }

        private void hardLaborForImmunity() {
            vitals.money.earnMoney((int)(imunities.Count * Constants.REWARD_FOR_BUYING_IMMUNITY));
        }

        private void reproduction() {
            IList<Virus> newViruses = new List<Virus>();
            foreach (Virus v in viruses) {
                ((List<Virus>)newViruses).AddRange(v.getRandomKids(boughtEffects.Count));
            }

            // TODO: it cannot be cured if there is still virus it's than infected
            if (viruses.Count != 0) lungsState = LungsState.INFECTED;

            if (viruses.Count + newViruses.Count > cells.Count) {
                newViruses = (new ListFilter<Virus>()).fillList(newViruses[0], cells.Count);
                lungsState = LungsState.DESTROYED;
            }

            ((List<Virus>)viruses).AddRange(newViruses);

            IList<Immunity> newImmunity = new List<Immunity>();
            foreach (Immunity v in imunities) {
                ((List<Immunity>)newImmunity).AddRange(v.getRandomKids(boughtEffects.Count));
            }

            if (imunities.Count + newImmunity.Count > cells.Count) {
                newImmunity = (new ListFilter<Immunity>()).fillList(newImmunity[0], cells.Count);
                if ( viruses.Count == 0) {
                    lungsState = LungsState.CURED;
                }
            }

            ((List<Immunity>)imunities).AddRange(newImmunity);

            // earn some small amount of money by reproduction
            vitals.money.earnMoney((int) ((newViruses.Count + newImmunity.Count) * Constants.REWARD_FOR_ANY_CELL_REPRODUCTION));
        }

        private bool increaseDay() {
            if (dayTime == DayTime.SLEEP) return false;
            switch ((++time) % 4) {
                case (int) 0:
                    dayTime = DayTime.MORNING;
                    break;
                case (int) 1:
                    dayTime = DayTime.NOON;
                    break;
                case (int) 2:
                    dayTime = DayTime.EVENING;
                    break;
                case (int) 3:
                    dayTime = DayTime.SLEEP;
                    return false;
                default:
                    return false;
            }

            return true;
        }

        private double healthCheck(bool change) {
            double value = 0;
            //TODO: Should health be added when effects are POSITIVE?
            foreach (var v in viruses) {
                value += 2*Constants.MAX_LOST_HEALTH_PER_LOST_ENERGY - (Constants.MAX_LOST_HEALTH_PER_LOST_ENERGY + (((Constants.MAX_LOST_HEALTH_PER_LOST_ENERGY + v.getHarmnessLevel()) * vitals.energy.currentEnergy)/100));
            }

            if (change) vitals.health.applyChanges(value);
            return value;
        }

        public double getHealthToChange() {
            return healthCheck(false);
        }
    }
}
