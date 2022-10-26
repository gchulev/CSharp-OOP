using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private readonly PlanetRepository planets;

        public Controller()
        {
            this.planets = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);

            if (planet is null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            IMilitaryUnit unit;
            if (unitTypeName == "AnonymousImpactUnit" )
            {
                unit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == "SpaceForces")
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == "StormTroopers")
            {
                unit = new StormTroopers();
            }
            else
            {
                throw new InvalidOperationException($"{unitTypeName} still not available!");
            }

            if (planet.Army.Any(mu => mu.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException($"{unitTypeName} already added to the Army of {planetName}!");
            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);

            return $"{unitTypeName} added successfully to the Army of {planetName}!";
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = this.planets.FindByName(planetName);

            if (planet is null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            IWeapon weapon;

            if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException($"{weaponTypeName} still not available!");
            }

            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException($"{weaponTypeName} already added to the Weapons of {planetName}!");
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return $"{planetName} purchased {weaponTypeName}!";
        }

        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet = this.planets.FindByName(name);

            if (planet != null)
            {
                return $"Planet {name} is already added!";
            }

            planet = new Planet(name, budget);
            this.planets.AddItem(planet);

            return $"Successfully added Planet: {planet.Name}";
        }

        public string ForcesReport()
        {
            var sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (IPlanet planet in this.planets.Models)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = this.planets.FindByName(planetOne);
            IPlanet secondPlanet = this.planets.FindByName(planetTwo);

            string output = string.Empty;

            if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
            {
                firstPlanet.Spend(firstPlanet.Budget / 2);
                firstPlanet.Profit(secondPlanet.Budget / 2); // check what budget left means, left from where since this planet hasn't lost money yet?
                firstPlanet.Profit(secondPlanet.Army.Sum(arm => arm.Cost) + secondPlanet.Weapons.Sum(w => w.Price));
                this.planets.RemoveItem(secondPlanet.Name);

                output = $"{firstPlanet.Name} destructed {secondPlanet.Name}!";
            }
            else
            {
                secondPlanet.Spend(secondPlanet.Budget / 2);
                secondPlanet.Profit(firstPlanet.Budget / 2); // check what budget left means, left from where since this planet hasn't lost money yet?
                secondPlanet.Profit(firstPlanet.Army.Sum(arm => arm.Cost) + firstPlanet.Weapons.Sum(w => w.Price));
                this.planets.RemoveItem(firstPlanet.Name);

                output = $"{secondPlanet.Name} destructed {firstPlanet.Name}!";
            }

            if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower)
            {
                bool firstPlanetOnwsNuclear = firstPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon");
                bool secondPlanetOnwsNuclear = secondPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon");

                if ((firstPlanetOnwsNuclear && secondPlanetOnwsNuclear) || (!firstPlanetOnwsNuclear && !secondPlanetOnwsNuclear))
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);

                    output = "The only winners from the war are the ones who supply the bullets and the bandages!";
                }
                else if (firstPlanetOnwsNuclear && !secondPlanetOnwsNuclear)
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    firstPlanet.Profit(secondPlanet.Budget / 2); // check what budget left means, left from where since this planet hasn't lost money yet?
                    firstPlanet.Profit(secondPlanet.Army.Sum(arm => arm.Cost) + secondPlanet.Weapons.Sum(w => w.Price));
                    this.planets.RemoveItem(secondPlanet.Name);

                    output = $"{firstPlanet.Name} destructed {secondPlanet.Name}!";
                }
                else if (secondPlanetOnwsNuclear && !firstPlanetOnwsNuclear)
                {
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    secondPlanet.Profit(firstPlanet.Budget / 2); // check what budget left means, left from where since this planet hasn't lost money yet?
                    secondPlanet.Profit(firstPlanet.Army.Sum(arm => arm.Cost) + firstPlanet.Weapons.Sum(w => w.Price));
                    this.planets.RemoveItem(firstPlanet.Name);

                    output = $"{secondPlanet.Name} destructed {firstPlanet.Name}!";
                }
                
            }

            return output;
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);

            if (planet is null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException("No units available for upgrade!");
            }

            planet.Spend(1.25);

            return $"{planetName} has upgraded its forces!";
        }
    }
}
