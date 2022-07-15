using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public override List<Type> PreferedFood
        {
            get
            {
                return new List<Type>() { typeof(Vegetable), typeof(Fruit) };
            }
        }
        public override string ToString()
        {
            return $"{base.ToString()}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
