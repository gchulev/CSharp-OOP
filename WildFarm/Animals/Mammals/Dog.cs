using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }
        public override List<Type> PreferedFood
        {
            get
            {
                return new List<Type>() { typeof(Meat) };
            }
        }
        public override string ToString()
        {
            return $"{base.ToString()}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
