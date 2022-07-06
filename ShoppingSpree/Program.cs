using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main()
        {

            var people = new List<Person>();
            var products = new List<Product>();

            try
            {
                string[] peopleInput = Console.ReadLine().Split(';');
                foreach (string personInfo in peopleInput)
                {
                    string personName = personInfo.Split('=')[0];
                    decimal personMoney = decimal.Parse(personInfo.Split('=')[1]);

                    var person = new Person(personName, personMoney);
                    people.Add(person);
                }

                string[] productsList = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (string p in productsList)
                {
                    string productName = p.Split('=')[0];
                    decimal productPrice = decimal.Parse(p.Split('=')[1]);

                    var product = new Product(productName, productPrice);
                    products.Add(product);
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("END"))
                {
                    break;
                }
                string buyerName = input.Split()[0];
                string productName = input.Split()[1];

                try
                {
                    BuyProduct(buyerName, productName);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }

            }

            foreach (Person p in people)
            {
                if (p.Bag.Count == 0)
                {
                    Console.WriteLine($"{p.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{p.Name} - {string.Join(", ", p.Bag.Select(x => x.Name))}");
                }
            }


            void BuyProduct(string buyer, string productToBuy)
            {
                if (!people.Exists(p => p.Name.Equals(buyer)))
                {
                    return;
                }
                var person = people.Find(p => p.Name.Equals(buyer));

                if (!products.Exists(p => p.Name.Equals(productToBuy)))
                {
                    return;
                }
                var product = products.Find(p => p.Name.Equals(productToBuy));

                if (person.Money < product.Cost)
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }
                else
                {
                    person.Money -= product.Cost;
                    person.Bag.Add(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }

                
            }
        }
    }
}
