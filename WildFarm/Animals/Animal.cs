using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interfaces;

namespace WildFarm.Animals
{
    public abstract class Animal : IAnimal
    {

        private readonly IReadOnlyDictionary<string, double> _weightModifiers = new Dictionary<string, double>()
        {
            {"Hen", 0.35 },
            {"Owl", 0.25 },
            {"Mouse", 0.10 },
            {"Cat", 0.30 },
            {"Dog", 0.40 },
            {"Tiger", 1.00 }
        };

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.PreferedFood = new List<Type>();
            this.FoodEaten = 0;
        }
        public string Name { get; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; private set; }
        public virtual List<Type> PreferedFood { get; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}";
        }

        public string ProduceSound()
        {
            switch (this.GetType().Name)
            {
                case "Owl":
                    return $"Hoot Hoot";
                case "Hen":
                    return $"Cluck";
                case "Mouse":
                    return $"Squeak";
                case "Dog":
                    return $"Woof!";
                case "Cat":
                    return $"Meow";
                case "Tiger":
                    return $"ROAR!!!";
                default:
                    throw new Exception("Invalid Animal!");
            }
        }
        public void FeedAnimal(IFood food)
        {
            if (this.PreferedFood.Contains(food.GetType()))
            {
                double modifier = _weightModifiers[this.GetType().Name];
                this.Weight += food.Quantity * modifier;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new Exception($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
