using Raiding.Heroes;
using Raiding.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Paladin : BaseHero, IHero
    {
        public Paladin(string name) : base(name)
        {
            base.Power = 100;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
