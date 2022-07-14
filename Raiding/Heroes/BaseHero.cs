using System;
using System.Collections.Generic;
using System.Text;
using Raiding.Interfaces;

namespace Raiding.Heroes
{
    public abstract class BaseHero : IHero
    {
        public BaseHero(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
        public virtual int Power { get; protected set; }

        public abstract string CastAbility();
    }
}
