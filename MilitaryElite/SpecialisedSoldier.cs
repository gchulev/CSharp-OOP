using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string _corps;
        protected SpecialisedSoldier(string firstName, string lastName, int id, double salary, string corps) : base(firstName, lastName, id, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get
            {
                return this._corps;
            }
            private set
            {
                if (value != "Marines" && value != "Airforces")
                {
                    throw new ArgumentException("Invalid corps!");
                }
                this._corps = value;
            }

        }
    }
}
