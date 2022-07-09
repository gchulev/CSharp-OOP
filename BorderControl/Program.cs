
namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        static void Main()
        {
            var entitiesCollection = new List<IIdentifiable>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command.Equals("End"))
                {
                    break;
                }
                string[] input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (input.Length == 2)
                {
                    string model = input[0];
                    string id = input[1];

                    var robot = new Robot(model, id);
                    entitiesCollection.Add(robot);
                }
                else if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];

                    var citizen = new Citizen(name, age, id);
                    entitiesCollection.Add(citizen);
                }
            }

            string fakeId = Console.ReadLine();
            var result = entitiesCollection.Where(e => e.Id.EndsWith(fakeId));
            Console.WriteLine(string.Join(Environment.NewLine, result.Select(x => string.Join(Environment.NewLine, x.Id))));
        }
    }
}
