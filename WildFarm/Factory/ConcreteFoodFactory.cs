using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;
using WildFarm.Interfaces;

namespace WildFarm.Factory
{
    public class ConcreteFoodFactory : FoodFactory
    {
        public override IFood CreateFood(string foodType, int foodQuantity)
        {
            if (foodType.Equals("Vegetable"))
            {
                return new Vegetable(foodQuantity);
            }
            else if (foodType.Equals("Fruit"))
            {
                return new Fruit(foodQuantity);
            }
            else if (foodType.Equals("Seeds"))
            {
                return new Seeds(foodQuantity);
            }
            else if (foodType.Equals("Meat"))
            {
                return new Meat(foodQuantity);
            }
            else
            {
                throw new Exception("Invalid Food!");
            }
        }
    }
}
