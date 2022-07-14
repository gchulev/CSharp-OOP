using System;
using System.Collections.Generic;
using System.Text;
using Raiding.Interfaces;

namespace Raiding.Factory
{
    public abstract class HeroFactory
    {
        public abstract IHero CreateHero(string type, string name);
    }
}
