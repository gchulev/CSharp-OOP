using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string _fullName;
        private bool _canRace;
        private IFormulaOneCar _car;
        private int _numberOfWins;

        private Pilot()
        {
            this.CanRace = false;
            this.NumberOfWins = 0;
        }
        public Pilot(string fullName) : this()
        {
            this.FullName = fullName;
        }

        public string FullName
        {
            get
            {
                return this._fullName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }
                this._fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get
            {
                return this._car;
            }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException(string.Format(ExceptionMessages.InvalidCarForPilot, value));
                }
                this._car = value;
            }
        }

        public int NumberOfWins
        {
            get
            {
                return this._numberOfWins;
            }
            private set
            {
                this._numberOfWins = value;
            }
        }

        public bool CanRace
        {
            get
            {
                return this._canRace;
            }
            private set
            {
                this._canRace = value;
            }
        }

        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            this.CanRace = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
        }
    }
}
