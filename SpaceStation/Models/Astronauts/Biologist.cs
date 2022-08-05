using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double InitialOxigene = 70;
        public Biologist(string name) : base(name, InitialOxigene)
        {
        }

        public override void Breath()
        {
            base.Oxygen -= 5;

            if (base.Oxygen <= 0)
            {
                base.Oxygen = 0;
            }
        }
    }
}
