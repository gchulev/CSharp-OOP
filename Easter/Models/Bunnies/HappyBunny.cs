using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private const int ENERGY = 100;
        public HappyBunny(string name) : base(name, ENERGY)
        {
        }

        public override void Work()
        {
            this.Energy -= 10;
            if (this.Energy < 0)
            {
                this.Energy = 0;
            }
        }
    }
}
