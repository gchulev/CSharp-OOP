using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string _raceName;
        private int _numberOfLaps;
        private bool _tookPlace;
        private readonly ICollection<IPilot> _pilots;

        public Race(string raceName, int numberOfLaps)
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
            this.TookPlace = false;
            this._pilots = new List<IPilot>();
        }
        public string RaceName
        {
            get
            {
                return this._raceName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
                this._raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get
            {
                return this._numberOfLaps;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                this._numberOfLaps = value;
            }
        }

        public bool TookPlace { get => this._tookPlace; set => this._tookPlace = value; }

        public ICollection<IPilot> Pilots => this._pilots;

        public void AddPilot(IPilot pilot)
        {
            this._pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            return $"The {this.RaceName} race has:{Environment.NewLine}Participants: {this.Pilots.Count(x => x.CanRace)}{Environment.NewLine}" +
                   $"Number of laps: {this.NumberOfLaps}{Environment.NewLine}Took place: {(this.TookPlace ? "Yes":"No")}";
        }
    }
}
