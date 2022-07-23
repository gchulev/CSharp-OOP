using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository _heroRepository;
        private WeaponRepository _weaponRepository;
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public string HeroReport()
        {
            throw new NotImplementedException();
        }

        public string StartBattle()
        {
            throw new NotImplementedException();
        }
    }
}
