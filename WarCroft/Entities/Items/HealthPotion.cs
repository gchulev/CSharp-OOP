using System;
using System.Collections.Generic;
using System.Text;

using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int WEIGHT = 5;
        public HealthPotion() : base(WEIGHT)
        {
        }
        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead); //check if we should throw an exception here
            }
            //TODO: Implement health increase lolgic after implementing the Character class logic
        }
    }
}
