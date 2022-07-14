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
            switch (type)
            {
                case "Druid":
                    return new Druid(name);
                case "Paladin":
                    return new Paladin(name);
                case "Rogue":
                    return new Rogue(name);
                case "Warrior":
                    return new Warrior(name);
                default:
                    throw new InvalidHeroException("Invalid hero!");
            }
        }
    }
}
