using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interfaces;

namespace WildFarm.Factory
{
    public abstract class FoodFactory
    {
        public abstract IFood CreateFood(string foodType, int foodQuantity);
    }
}
