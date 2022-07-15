using System;
using System.Collections.Generic;
using WildFarm.Animals;
using WildFarm.Factory;
using WildFarm.Foods;
using WildFarm.Interfaces;

namespace WildFarm
{
    public class Program
    {
        static void Main()
        {
            var animals = new List<IAnimal>();
            var animalFactory = new ConcreteAnimalFactory();
            var foodFactory = new ConcreteFoodFactory();

            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("End"))
                {
                    break;
                }
                string[] animalArgs = input.Split();
                string[] foodArgs = Console.ReadLine().Split();

                try
                {
                    var animal = BuildAnimalWithFactory(animalArgs);
                    var food = foodFactory.CreateFood(foodArgs[0], int.Parse(foodArgs[1]));

                    Console.WriteLine(animal.ProduceSound());
                    animal.FeedAnimal(food);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }

            IAnimal BuildAnimalWithFactory(string[] animalArgs)
            {
                string animalType = animalArgs[0];
                string name = animalArgs[1];
                double weight = double.Parse(animalArgs[2]);
                IAnimal animal;

                if (animalArgs.Length == 4)
                {
                    string fourthParam = animalArgs[3];
                    animal = animalFactory.CreateAnimal(animalType, name, weight, fourthParam);
                    animals.Add(animal);
                }
                else if (animalArgs.Length == 5)
                {
                    string fourthParam = animalArgs[3];
                    string fifthParam = animalArgs[4];
                    animal = animalFactory.CreateAnimal(animalType, name, weight, fourthParam, fifthParam);
                    animals.Add(animal);
                }
                else
                {
                    throw new ArgumentException("Invalid arguments!");
                }
                return animal;
            }

        }
    }
}
