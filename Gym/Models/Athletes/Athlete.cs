using System;
using System.Collections.Generic;
using System.Text;

using Gym.Models.Athletes.Contracts;

namespace Gym.Models.Athletes
{
    public abstract class Athlete : IAthlete
    {
        private string fullname;
        private string motivation;
        private int stamina;
        private int numberOfMedals;

        public Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            this.FullName = fullName;
            this.Motivation = motivation;
            this.Stamina = stamina;
            this.NumberOfMedals = numberOfMedals;
        }

        public string FullName
        {
            get
            {
                return this.fullname;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Athlete name cannot be null or empty.");
                }
                this.fullname = value;
            }
        }

        public string Motivation
        {
            get
            {
                return this.motivation;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The motivation cannot be null or empty.");
                }
                this.motivation = value;
            }
        }

        public int Stamina
        {
            get
            {
                return this.stamina;
            }
            protected set
            {
                this.stamina = value;
            }
        }

        public int NumberOfMedals
        {
            get
            {
                return this.numberOfMedals;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Athlete's number of medals cannot be below 0.");
                }
                this.numberOfMedals = value;
            }
        }

        public abstract void Exercise();
        
    }
}
