using System;
using System.Collections.Generic;
using System.Text;

using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Models.Drivers
{
    public class Driver : IDriver
    {
        private string name;
        public Driver(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }

                this.name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate => this.Car != null;

        public void AddCar(ICar car)
        {
            if (car is null)
            {
                throw new ArgumentException("Car cannot be null.");
            }
            this.Car = car;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
