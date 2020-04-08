using System.Collections;
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

            this.viruses = (new ListFilter<Virus>()).fillList(new Virus(), difficulty);
            this.imunities = (new ListFilter<Immunity>()).fillList(new Immunity(), 0);
            this.cells = (new ListFilter<Cell>()).fillList(new Cell(), 150);
            this.boughtEffects = new List<Effect>();
        }

        public int fight() {
            if (!increaseDay()) {
                //TODO: You are sleeping!
                return 0;
            }

            int virusesCount = viruses.Count;
            int imunitieCounts = imunities.Count;

            if (virusesCount > imunitieCounts) {
                virusesCount = virusesCount - imunitieCounts;
                imunitieCounts = 0;
                if (virusesCount < 0) {
                    virusesCount = 0;
                }
            } else {
                imunitieCounts = imunitieCounts - virusesCount;
                virusesCount = 0;
                if (imunitieCounts < 0) {
                    imunitieCounts = 0;
                }
            }

            int virusesSize = viruses.Count;
            for (int i = virusesSize - virusesCount - 1; i >= 0; i--) {
                viruses.RemoveAt(i);
            }

            int immunitiesSize = imunities.Count;
            for (int i = immunitiesSize - imunitieCounts - 1; i >= 0; i--) {
                imunities.RemoveAt(i);
            }

            vitals.money.earnMoney((int)(immunitiesSize - imunities.Count * Constants.REWARD_FOR_FIGHT));

            return immunitiesSize - imunities.Count;
        }

        public bool buyEffect(Effect effect) {
            if (!vitals.money.butStuff(effect.dnaPrice)) return false;
            if (effect.isActive) return false;
            if (boughtEffects.Contains(effect)) return false;

            boughtEffects.Add(effect);
            effect.isActive = true;

            return true;
        }
        public bool addVirus() {
            if (lungsState == LungsState.INFECTED) {
                return false;
            }
            viruses.Add(new Virus());

            lungsState = LungsState.INFECTED;
            return true;
        }

        public virtual bool addImmunities(IList<Immunity> imumnityToAdd) {
            if (imunities.Count + imumnityToAdd.Count > cells.Count) {
                return false;
            }
            if (!vitals.money.butStuff(imumnityToAdd.Count)) {
                return false;
            }

             ((List<Immunity>) imunities).AddRange(imumnityToAdd);
            return true;
        }

        public virtual void endDay() {
            hardLaborForImmunity();
            healthCheck();
            reproduction();
            dayTime = DayTime.MORNING;
            time = 0;
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
                lungsState = LungsState.CURED;
            }

           ((List<Immunity>)imunities).AddRange(newImmunity);

            // earn some small amount of money by reproduction
            vitals.money.earnMoney((int)((newViruses.Count + newImmunity.Count) * Constants.REWARD_FOR_ANY_CELL_REPRODUCTION));
        }

        private bool increaseDay() {
            if (dayTime == DayTime.SLEEP) return false;
            switch ((time++) % 4) {
                case (int)DayTime.MORNING:
                    dayTime = DayTime.MORNING;
                    break;
                case (int)DayTime.NOON:
                    dayTime = DayTime.NOON;
                    break;
                case (int)DayTime.EVENING:
                    dayTime = DayTime.EVENING;
                    break;
                case (int)DayTime.SLEEP:
                    dayTime = DayTime.SLEEP;
                    return false;
                default:
                    return false;
            }

            return true;
        }

        private double healthCheck() {
            double value = 0;
            //TODO: Should health be added when effects are POSITIVE?
            foreach (var v in viruses) {
                value = Constants.MAX_LOST_HEALTH_PER_LOST_ENERGY - ((Constants.MAX_LOST_HEALTH_PER_LOST_ENERGY - v.getHarmnessLevel()) * vitals.energy.currentEnergy / 100);
            }

            if (viruses.Count == 0 && boughtEffects.Count == PositiveEffects.getEffectList.Count && lungsState == LungsState.INFECTED) {
                lungsState = LungsState.CURED;
            }
            vitals.health.applyChanges(value);
            return value;
        }
    }
}
