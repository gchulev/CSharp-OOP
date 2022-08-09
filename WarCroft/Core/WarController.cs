using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private readonly List<Character> party;
        private readonly List<Item> items;
        public WarController()
        {
            this.party = new List<Character>();
            this.items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
             string characterType = args[0];
             string characterName = args[1];

            Character character;

            if (characterType == "Warrior")
            {
                character = new Warrior(characterName);
            }
            else if (characterType == "Priest")
            {
                character = new Priest(characterName);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }

            this.party.Add(character);
            return $"{character.Name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item;

            if (itemName == "FirePotion")
            {
                item = new FirePotion();
            }
            else if (itemName == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidItem, itemName));
            }

            this.items.Add(item);
            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character currentCharacter = this.party.FirstOrDefault(c => c.Name == characterName);

            if (currentCharacter is null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Item lastPoolItem = this.items.LastOrDefault();
            this.items.Remove(lastPoolItem);
            currentCharacter.Bag.AddItem(lastPoolItem);

            return $"{characterName} picked up {lastPoolItem.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = this.party.FirstOrDefault(c => c.Name == characterName);

            if (character is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);
            
            return $"{character.Name} used {itemName}.";
        }

        public string GetStats()
        {
            var sb = new StringBuilder();

            foreach (Character character in this.party.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {(character.IsAlive ? "Alive" : "Dead" )}");
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = this.party.FirstOrDefault(c => c.Name == attackerName);
            Character receiver = this.party.FirstOrDefault(c => c.Name == receiverName);

            if (attacker is null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            else if (receiver is null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }
            
            if (attacker.GetType().Name != "Warrior")
            {
                throw new ArgumentException(String.Format(ExceptionMessages.AttackFail, attacker.Name));
            }

            Warrior currentAttacker = attacker as Warrior;
            currentAttacker.Attack(receiver);

            var sb = new StringBuilder();

            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{currentAttacker.Name} attacks {receiverName} for {currentAttacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
                sb.AppendLine($"{receiver.Name} is dead!");
            }
            else
            {
                sb.AppendLine($"{currentAttacker.Name} attacks {receiverName} for {currentAttacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
            }
            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = this.party.FirstOrDefault(c => c.Name == healerName);
            Character healingReceiver = this.party.FirstOrDefault(c => c.Name == healingReceiverName);

            if (healer is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }
            else if (healingReceiver is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }

            if (healer.GetType().Name != "Priest")
            {
                throw new ArgumentException(String.Format(ExceptionMessages.HealerCannotHeal, healer.Name));
            }

            Priest currentHealer = healer as Priest;
            currentHealer.Heal(healingReceiver);

            return $"{currentHealer.Name} heals {healingReceiver.Name} for {currentHealer.AbilityPoints}! {healingReceiver.Name} has {healingReceiver.Health} health now!";
        }
    }
}
