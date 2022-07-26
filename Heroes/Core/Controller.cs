using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Heroes.Models.Weapons;
using Heroes.Models.Map;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private readonly HeroRepository _heroRepository;
        private readonly WeaponRepository _weaponRepository;

        public Controller()
        {
            this._heroRepository = new HeroRepository();
            this._weaponRepository = new WeaponRepository();
        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = this._heroRepository.Models.FirstOrDefault(h => h.Name == heroName);
            IWeapon weapon = this._weaponRepository.Models.FirstOrDefault(w => w.Name == weaponName);

            if (hero is null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            else if (weapon is null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }
            else if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {hero.Name} is well-armed.");
            }

            hero.AddWeapon(weapon);
            this._weaponRepository.Remove(weapon);
            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            switch (type)
            {
                case "Barbarian":
                    if (!this._heroRepository.Models.Any(h => h.Name == name))
                    {
                        var hero = new Barbarian(name, health, armour);
                        this._heroRepository.Add(hero);
                        return $"Successfully added Barbarian {name} to the collection.";
                    }

                    throw new InvalidOperationException($"The hero {name} already exists.");

                case "Knight":
                    if (!this._heroRepository.Models.Any(h => h.Name == name))
                    {
                        var hero = new Knight(name, health, armour);
                        this._heroRepository.Add(hero);
                        return $"Successfully added Sir {name} to the collection.";
                    }

                    throw new InvalidOperationException($"The hero {name} already exists.");

                default:
                    throw new InvalidOperationException("Invalid hero type.");
            }
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (type == "Mace")
            {
                if (!this._weaponRepository.Models.Any(w => w.Name == name))
                {
                    IWeapon wep = new Mace(name, durability);
                    this._weaponRepository.Add(wep);
                    return $"A {type.ToLower()} {name} is added to the collection.";
                }

                throw new InvalidOperationException($"The weapon {name} already exists.");
            }
            else if (type == "Claymore")
            {
                if (!this._weaponRepository.Models.Any(w => w.Name == name))
                {
                    IWeapon wep = new Claymore(name, durability);
                    this._weaponRepository.Add(wep);
                    return $"A {type.ToLower()} {name} is added to the collection.";
                }

                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            throw new InvalidOperationException("Invalid weapon type.");
        }

        public string HeroReport()
        {
            var orderedHeroesCollection = this._heroRepository.Models.OrderBy(h => h.GetType().Name).ThenByDescending(h => h.Health).ThenBy(h => h.Name);
            StringBuilder sb = new StringBuilder();

            foreach (IHero hero in orderedHeroesCollection)
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");
                if (hero.Weapon != null)
                {
                    sb.AppendLine($"--Weapon: {hero.Weapon.Name}");
                }
                else
                {
                    sb.AppendLine($"--Weapon: Unarmed");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            Map map = new Map();
            return map.Fight(this._heroRepository.Models.Where(h => h.IsAlive == true && h.Weapon != null).ToList());
        }
    }
}
