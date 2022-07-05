using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main()
        {
            var animalsList = new List<Animal>();

            while (true)
            {
                try
                {
                    string command = Console.ReadLine();
                    if (command.Equals("Beast!"))
                    {
                        break;
                    }

                    string[] animalInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string name = animalInfo[0];
                    int age = int.Parse(animalInfo[1]);

                    if (command.Equals("Cat"))
                    {
                        string gender = animalInfo[2];

                        Animal cat = new Cat(name, age, gender);
                        animalsList.Add(cat);
                    }
                    else if (command.Equals("Dog"))
                    {
                        string gender = animalInfo[2];

                        Animal dog = new Dog(name, age, gender);
                        animalsList.Add(dog);
                    }
                    else if (command.Equals("Frog"))
                    {
                        string gender = animalInfo[2];

                        Animal frog = new Frog(name, age, gender);
                        animalsList.Add(frog);
                    }
                    else if (command.Equals("Kitten"))
                    {
                        Animal kitten = new Kitten(name, age);
                        animalsList.Add(kitten);
                    }
                    else if (command.Equals("Tomcat"))
                    {
                        Animal tomcat = new Tomcat(name, age);
                        animalsList.Add(tomcat);

                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid input!");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                    break;
                }
                
            }

            foreach (Animal animal in animalsList)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                Console.WriteLine(animal.ProduceSound()); 
            }
        }
    }
}
