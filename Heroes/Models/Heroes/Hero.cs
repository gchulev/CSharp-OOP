using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string _name;
        private int _health;
        private int _armour;
        private IWeapon _weapon;

        public Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }
        public string Name 
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this._name))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
                return this._name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
                this._name = value;
            }
        }

        public int Health 
        {
            get
            {
                return this._health;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                this._health = value;
            }
        }

        public int Armour
        {
            get
            {
                return this._armour;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                this._armour = value;
            }
        }

        public IWeapon Weapon 
        {
            get => this._weapon;
            private set
            {
                this._weapon = value;
            }
        }

        public bool IsAlive { get => this._health > 0; }

        public void AddWeapon(IWeapon weapon)
        {
            this._weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            this._armour -= points;

            if (this._armour <= 0)
            {
                int damageToHealthPool = Math.Abs(this._armour);
                this._armour = 0;

                this._health -= damageToHealthPool;
                if (this._health <= 0)
                {
                    this._health = 0;
                }
            }
        }
    }
}
