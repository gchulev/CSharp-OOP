using Raiding.Heroes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Interfaces
{
    public class Rogue : BaseHero, IHero
    {
        public Rogue(string name) : base(name)
        {
            base.Power = 80;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
