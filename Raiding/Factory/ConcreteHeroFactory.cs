using Raiding.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Raiding.Exceptions;

namespace Raiding.Factory
{
    public class ConcreteHeroFactory : HeroFactory
    {
        public override IHero CreateHero(string type, string name)
        {
            return type switch
            {
                "Druid" => new Druid(name),
                "Paladin" => new Paladin(name),
                "Rogue" => new Rogue(name),
                "Warrior" => new Warrior(name),
                _ => throw new InvalidHeroException("Invalid hero!"),
            };
        }
    }
}
