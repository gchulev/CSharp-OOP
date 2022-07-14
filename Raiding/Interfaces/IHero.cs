using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Interfaces
{
    public interface IHero
    {
        public string Name { get;}
        public int Power { get; }

        public string CastAbility();
    }
}
