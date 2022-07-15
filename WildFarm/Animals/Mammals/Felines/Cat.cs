using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals.Felines;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override List<Type> PreferedFood
        {
            get
            {
                return new List<Type>() { typeof(Vegetable), typeof(Meat) };
            }
        }
    }
}
