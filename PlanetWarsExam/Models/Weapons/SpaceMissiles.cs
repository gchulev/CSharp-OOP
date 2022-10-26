using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public class SpaceMissiles : Weapon
    {
        private const double PRICE = 8.75;
        private int destructionLevel;
        public SpaceMissiles(int destructionLevel)
            : base(destructionLevel, PRICE)
        {
        }

        public override int DestructionLevel
        {
            get => this.destructionLevel;
            protected set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Destruction level cannot be zero or negative.");
                }
                else if (value > 10)
                {
                    throw new ArgumentException("Destruction level cannot exceed 10 power points.");
                }

                this.destructionLevel = value;
            }
        }
    }
}
