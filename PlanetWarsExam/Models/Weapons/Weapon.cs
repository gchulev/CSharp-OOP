using System;
using System.Collections.Generic;
using System.Text;

using PlanetWars.Models.Weapons.Contracts;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        public Weapon(int destructionLevel, double price)
        {
            this.DestructionLevel = destructionLevel;
            this.Price = price;
        }
        public double Price { get; }

        public abstract int DestructionLevel { get; protected set; }
    }
}
