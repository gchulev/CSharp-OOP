using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals;
using WildFarm.Animals.Birds;
using WildFarm.Animals.Mammals;
using WildFarm.Animals.Mammals.Felines;
using WildFarm.Interfaces;

namespace WildFarm.Factory
{
    public class ConcreteAnimalFactory : AnimalFactory
    {
        public override IAnimal CreateAnimal(string type, string name, double weight, string fourthParam, string fifthParam = null)
        {
            Animal animal;
            if (type.Equals("Hen"))
            {
                animal = new Hen(name, weight, double.Parse(fourthParam));
            }
            else if (type.Equals("Owl"))
            {
                animal = new Owl(name, weight, double.Parse(fourthParam));
            }
            else if (type.Equals("Cat"))
            {
                animal = new Cat(name, weight, fourthParam, fifthParam);
            }
            else if (type.Equals("Tiger"))
            {
                animal = new Tiger(name, weight, fourthParam, fifthParam);
            }
            else if (type.Equals("Dog"))
            {
                animal = new Dog(name, weight, fourthParam);
            }
            else if (type.Equals("Mouse"))
            {
                animal = new Mouse(name, weight, fourthParam);
            }
            else
            {
                throw new Exception("Invalid Animal!");
            }
            return animal;
        }
    }
}
