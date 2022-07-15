using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Felines
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, string livingRegion, string breed) : base(name, weight)
        {
            this.LivingRegion = livingRegion;
            this.Breed = breed;
        }

        public string Breed { get; protected set; }

        public override string ToString()
        {
            return $"{base.ToString()}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
