using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Repositories.Contracts;

namespace Easter.Core
{
    public class Controller : IController
    {
        private readonly BunnyRepository bunnies;
        private readonly EggRepository eggs;

        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;

            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException("Invalid bunny type.");
            }

            this.bunnies.Add(bunny);
            return $"Successfully added {bunnyType} named {bunnyName}.";

        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = this.bunnies.FindByName(bunnyName);
            IDye dye = new Dye(power);

            if (bunny is null)
            {
                throw new InvalidOperationException("The bunny you want to add a dye to doesn't exist!");
            }

            bunny.AddDye(dye);
            return $"Successfully added dye with power {dye.Power} to bunny {bunny.Name}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            this.eggs.Add(egg);
            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            var suitableBunnies = this.bunnies.Models.Where(b => b.Energy >= 50).OrderByDescending(b => b.Energy).ToList();

            if (suitableBunnies.Count == 0)
            {
                throw new InvalidOperationException("There is no bunny ready to start coloring!");
            }
            IEgg egg = this.eggs.FindByName(eggName);

            var workshop = new Workshop();

            foreach (IBunny bunny in suitableBunnies)
            {
                workshop.Color(egg, bunny);

                if (bunny.Energy == 0)
                {
                    this.bunnies.Remove(bunny);
                }
            }

            return $"Egg {egg.Name} is {(egg.IsDone() ? "done" : "not done")}.";
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.eggs.Models.Count(x => x.IsDone())} eggs are done!");
            sb.AppendLine("Bunnies info:");

            foreach (Bunny bunny in this.bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Count(d => !d.IsFinished())} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
