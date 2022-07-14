using Raiding.Heroes;
using Raiding.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Druid : BaseHero, IHero
    {
        public Druid(string name) : base(name)
        {
            this.Power = 80;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
