using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override List<Type> PreferedFood
        {
            get
            {
                return new List<Type>() { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds)};
            }
        }

    }
}
