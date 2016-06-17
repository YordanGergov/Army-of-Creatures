using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Specialties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyOfCreatures.Extended.Specialties
{
    public class DoubleDamage: Specialty
    {
        private int rounds;

        public DoubleDamage(int rounds)
        {
            if (rounds <= 0)
            {
                throw new ArgumentOutOfRangeException("rounds", "The number of rounds should be greater than 0");
            }

            if (rounds >= 11)
            {
                throw new ArgumentOutOfRangeException("rounds", "The number of rounds should not be greater than 10");
            }

            this.rounds = rounds;
        }

        public override decimal ChangeDamageWhenAttacking(ICreaturesInBattle atackerWithSpecialty, ICreaturesInBattle attacker, decimal currentDamage)
        {
            if (atackerWithSpecialty == null)
            {
                throw new ArgumentNullException("defenderWithSpecialty");
            }

            if (attacker == null)
            {
                throw new ArgumentNullException("attacker");
            }

            if (this.rounds <= 0)
            {
                // Effect expires after fixed number of rounds
                return currentDamage;
            }

            this.rounds--;
            return currentDamage * 2.0M;

        }


        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.rounds);
        }
    }
}
