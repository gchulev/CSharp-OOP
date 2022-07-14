using System;
using Raiding.Exceptions;
using Raiding.Factory;
using System.Collections.Generic;
using Raiding.Interfaces;
using System.Linq;

namespace Raiding
{
    public class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var raid = new List<IHero>();
            HeroFactory heroFactory = new ConcreteHeroFactory();
            int counter = 0;

            while (counter != n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    var hero = heroFactory.CreateHero(heroType, heroName);
                    if (!raid.Exists(h => h.Name.Equals(heroName)))
                    {
                        raid.Add(hero);
                        counter++;
                    }
                }
                catch (InvalidHeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            int bossPower = int.Parse(Console.ReadLine());
            foreach (IHero hero in raid)
            {
                Console.WriteLine(hero.CastAbility());
            }
            if (raid.Sum(h => h.Power) >= bossPower)
            {
                Console.WriteLine($"Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
