using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Program
    {
        static void Main()
        {
            try
            {
                string pizzaName = Console.ReadLine().Split()[1];

                string[] input = Console.ReadLine().Split();
                string doughType = input[1];
                string bakingTechnique = input[2];
                double doughGrams = double.Parse(input[3]);
                var dough = new Dough(doughType, bakingTechnique, doughGrams);

                var pizza = new Pizza(pizzaName)
                {
                    Dough = dough

                };

                while (true)
                {
                    string[] command = Console.ReadLine().Split();
                    if (command[0].Equals("END"))
                    {
                        break;
                    }
                    string toppingType = command[1];
                    double toppingGrams = double.Parse(command[2]);
                    var topping = new Topping(toppingType, toppingGrams);
                    pizza.AddTopping(topping);

                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


        }
    }
}
