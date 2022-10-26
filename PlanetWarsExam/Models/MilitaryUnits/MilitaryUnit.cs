using System;
using System.Collections.Generic;
using System.Text;

using PlanetWars.Models.MilitaryUnits.Contracts;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        public MilitaryUnit(double cost)
        {
            this.EnduranceLevel = 1;
            this.Cost = cost;
        }
        public double Cost { get; }

        public int EnduranceLevel { get; private set; }

        public void IncreaseEndurance()
        {
            this.EnduranceLevel++;

            if (this.EnduranceLevel > 20)
            {
                this.EnduranceLevel = 20;

                throw new ArgumentException("Endurance level cannot exceed 20 power points.");
            }
        }
    }
}
