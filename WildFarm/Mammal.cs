using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals;

namespace WildFarm
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight) : base(name, weight)
        {
        }

        public string LivingRegion { get; protected set; }
    }
}
