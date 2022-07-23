using Heroes.Core;
using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using System.Collections.Generic;

namespace Heroes
{
    public class StartUp
    {
        public static void Main()
        {

            IWeapon weapon1 = new Mace("Mace", 12);
            IWeapon weapon2 = new Claymore("CL", 30);
            //var amceResult = weapon1.DoDamage();
            //var claymoreResult = weapon2.DoDamage();

            IHero hero1 = new Barbarian("Conan", 100, 150);
            IHero hero2 = new Knight("Merlin", 80, 200);

            ICollection<IHero> players = new List<IHero>();
            players.Add(hero1);
            players.Add(hero2);

            hero1.AddWeapon(weapon1);
            hero2.AddWeapon(weapon2);

            hero1.TakeDamage(250);
            hero2.TakeDamage(210);

            var map = new Map();
            var fightResult = map.Fight(players);

            //IEngine engine = new Engine();
            //engine.Run();
        }
    }
}
