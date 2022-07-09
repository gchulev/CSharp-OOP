using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    internal class Program
    {
        static void Main()
        {
            var buyers = new List<IBuyer>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (input.Length == 4)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthday = input[3];

                    var citizen = new Citizen(name, age, id, birthday);
                    buyers.Add(citizen);
                }
                else if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];

                    var rebel = new Rebel(name, age, group);
                    buyers.Add(rebel);
                }
            }

            while (true)
            {
                string name = Console.ReadLine();
                if (name.Equals("End"))
                {
                    break;
                }
                if (buyers.Exists(b => b.Name.Equals(name)))
                {
                    var buyer = buyers.FirstOrDefault(b => b.Name.Equals(name));
                    buyer.BuyFood();
                }
            }
            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}
