using System;
using System.Collections.Generic;
using System.Text;
using Raiding.Heroes;
using Raiding.Interfaces;

namespace Raiding
{
    public class Warrior : BaseHero, IHero
    {
        public Warrior(string name) : base(name)
        {
            base.Power = 100;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
