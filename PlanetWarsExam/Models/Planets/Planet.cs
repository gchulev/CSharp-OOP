using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private UnitRepository units;
        private WeaponRepository weapons;
        private string name;
        private double budget;

        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.weapons = new WeaponRepository();
            this.units = new UnitRepository();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Planet name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public double Budget
        {
            get => this.budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Budget's amount cannot be negative.");
                }

                this.budget = value;
            }
        }

        public double MilitaryPower => this.CalculateMilitaryPower();

        public IReadOnlyCollection<IMilitaryUnit> Army => this.units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            this.units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.budget} billion QUID");

            sb.AppendLine($"--Forces: {(this.Army.Count > 0 ? string.Join(", ", this.Army.Select(x => x.GetType().Name)) : "No units")}");
            sb.AppendLine($"--Combat equipment: {(this.Weapons.Count > 0 ? string.Join(", ", this.Weapons.Select(w => w.GetType().Name)) : "No weapons")}");
            sb.AppendLine($"--Military Power: {this.MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public void Spend(double amount)
        {
            if (amount > this.Budget)
            {
                throw new InvalidOperationException("Budget too low!");
            }
            this.Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (IMilitaryUnit unit in this.Army)
            {
                unit.IncreaseEndurance();
            }
        }

        private double CalculateMilitaryPower()
        {
            double endurancesSum = this.Army.Sum(s => s.EnduranceLevel);
            double wepDestroLevel = this.Weapons.Sum(w => w.DestructionLevel);
            double totalMilitaryPower = endurancesSum + wepDestroLevel;
            

            if (this.Army.Any(u => u.GetType().Name == "AnonymousImpactUnit"))
            {
                totalMilitaryPower += totalMilitaryPower * 0.3;
                
            }
            else if (this.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
            {
                totalMilitaryPower += totalMilitaryPower * 0.45;
               
            }

            return Math.Round(totalMilitaryPower, 3);
        }
    }
}
