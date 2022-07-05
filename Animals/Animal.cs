using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string _name;
        private int _age;
        private string _gender;

        protected Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.Name), "Invalid input!");
                }
                this._name = value;
            }
        }

        public int Age
        {
            get
            {
                return this._age;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(nameof(this.Name), "Age must be a possitive number!");
                }
                this._age = value;
            }
        }
        public string Gender
        {
            get
            {
                return this._gender;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.Gender), "Invalid gender!");
                }
                this._gender = value;
            }
        }

        public abstract void ProduceSound();

    }
}
