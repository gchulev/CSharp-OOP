﻿using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Heroes.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private string _name;
        private int _durability;
        public Weapon(string name, int durability)
        {
            this.Name = name;
            this.Durability = durability;
        }
        public string Name
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this._name))
                {
                    throw new ArgumentException("Weapon type cannot be null or empty.");
                }
                return this._name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Weapon type cannot be null or empty.");
                }
                this._name = value;
            }
        }

        public int Durability
        {
            get
            {
                return this._durability;
            }
            protected set
            {
                if (value < 0)
                {
                    this._durability = 0;
                    throw new ArgumentException("Durability cannot be below 0.");
                }
                this._durability = value;
            }
        }

        public int DoDamage()
        {
            Type weaponType = this.GetType();
            FieldInfo[] constFields = weaponType.GetFields(BindingFlags.NonPublic | BindingFlags.Static);
            int currentWeaponDamage = (int)constFields[0].GetValue(weaponType);


            if (this.Durability <= 0)
            {
                this.Durability--;
                return 0;
            }
            return currentWeaponDamage;
        }
    }
}
