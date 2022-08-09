using System;
using System.Collections.Generic;
using System.Text;

using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;

        public Captain(string fullname)
        {
            this.FullName = fullname;
            this.CombatExperience = 0;
            this.Vessels = new List<IVessel>();
        }

        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                this.fullName = value;
            }
        }

        public int CombatExperience
        {
            get => this.combatExperience;
            private set
            {
                this.combatExperience = value;
            }
        }

        public ICollection<IVessel> Vessels { get; }

        public void AddVessel(IVessel vessel)
        {
            if (vessel is null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }
            this.Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.FullName} has {this.CombatExperience} combat experience and commands {this.Vessels.Count} vessels.");

            if (this.Vessels.Count > 0)
            {
                sb.AppendLine(String.Join($"{Environment.NewLine}", this.Vessels).ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
