using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> heroes)
        {
            var knights = new List<IHero>();
            var barbarians = new List<IHero>();

            knights = heroes.Where(h => h.GetType() == typeof(Knight)).ToList();
            barbarians = heroes.Where(h => h.GetType().Name == typeof(Barbarian).Name).ToList();

            while (knights.Any(k => k.IsAlive) && barbarians.Any(b => b.IsAlive))
            {
                foreach (Knight knight in knights)
                {
                    foreach (Barbarian barbarian in barbarians)
                    {
                        if (knight.IsAlive && barbarian.IsAlive)
                        {
                            int damageDone = knight.Weapon.DoDamage();
                            barbarian.TakeDamage(damageDone);
                        }
                    }
                }

                foreach (Barbarian barbarian in barbarians)
                {
                    foreach (Knight knight in knights)
                    {
                        if (barbarian.IsAlive && knight.IsAlive) //TODO: check if we have to check if the knigh is alive if he is being hit. It is not clear from the task.
                        {
                            int damageDone = barbarian.Weapon.DoDamage();
                            knight.TakeDamage(damageDone);
                        }
                    }
                }

            }

            string result = string.Empty;

            if (knights.Any(k => k.IsAlive))
            {
                result = $"The knights took {knights.Count(k => k.IsAlive == false)} casualties but won the battle.";
            }
            if (barbarians.Any(b => b.IsAlive))
            {
                result = $"The barbarians took {barbarians.Count(b => b.IsAlive == false) } casualties but won the battle.";
            }

            return result;
        }
    }
}
