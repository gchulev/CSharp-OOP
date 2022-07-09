using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class Program
    {
        static void Main()
        {
            var entities = new List<IBirthDate>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command.Equals("End"))
                {
                    break;
                }
                string[] input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string entity = input[0];
                if (entity.Equals("Citizen"))
                {
                    string name = input[1];
                    int age = int.Parse(input[2]);
                    string id = input[3];
                    string bithdate = input[4];

                    var citizen = new Citizen(name, age, id, bithdate);
                    entities.Add(citizen);
                }
                else if (entity.Equals("Pet"))
                {
                    string name = input[1];
                    string birthDate = input[2];

                    var pet = new Pet(name, birthDate);
                    entities.Add(pet);
                }
            }
            string year = Console.ReadLine();

            var result = entities.Where(x => x.BirthDate.Split('/')[2] == year);
            Console.WriteLine(String.Join(Environment.NewLine, result.Select(x => string.Join(Environment.NewLine, x.BirthDate))));
        }
    }
}
