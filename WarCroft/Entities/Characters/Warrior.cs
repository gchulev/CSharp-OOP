using System;
using System.Collections.Generic;
using System.Text;

using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double HEALTH = 100;
        private const double ARMOR = 50;
        private const double AGILITYPOINTS = 40;

        public Warrior(string name)
            : base(name, HEALTH, ARMOR, AGILITYPOINTS, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();

            if (this.Name == character.Name)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
            character.TakeDamage(this.AbilityPoints);
        }
    }
}
