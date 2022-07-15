using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interfaces;

namespace WildFarm.Factory
{
    public abstract class AnimalFactory
    {
        public abstract IAnimal CreateAnimal(string type, string name, double weight, string fourthParam, string fifthParam);
    }
}
