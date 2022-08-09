using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        public Character(string name, double health, double armor, double abilityPoints, IBag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = this.BaseHealth;
            this.BaseArmor = armor;
            this.Armor = this.BaseArmor; // set Armor to the base Armor of the Character on Init
            this.Bag = bag;
            this.AbilityPoints = abilityPoints;
        }
        public bool IsAlive { get; set; } = true;

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; }
        public double Health
        {
            get => this.health;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (value > this.BaseHealth)
                {
                    value = this.BaseHealth;
                }

                this.health = value;
            }
        }
        public double BaseArmor { get; }
        public double Armor
        {
            get => this.armor;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.armor = value;
            }
        }
        public IBag Bag { get; }
        public double AbilityPoints { get; }
        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            double transfferedDamage = this.Armor - hitPoints;

            if (transfferedDamage <= 0)
            {
                this.Armor -= hitPoints;
                this.Health -= Math.Abs(transfferedDamage);

                if (this.Health <= 0)
                {
                    this.IsAlive = false;
                }
            }
            else
            {
                this.Armor -= hitPoints;
            }
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();
            item.AffectCharacter(this);
        }
        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}