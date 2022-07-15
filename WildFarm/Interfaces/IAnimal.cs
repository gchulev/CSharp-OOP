using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Interfaces
{
    public interface IAnimal
    {
        public string Name { get; }
        public double Weight { get; }

        public string ProduceSound();

        public void FeedAnimal(IFood food);
    }
}
