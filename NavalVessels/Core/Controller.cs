using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private readonly VesselRepository vessels;
        private readonly List<ICaptain> captains;

        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new List<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            IVessel vessel = this.vessels.FindByName(selectedVesselName);
            ICaptain captain = this.captains.FirstOrDefault(c => c.FullName == selectedCaptainName);

            if (captain is null)
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }
            if (vessel is null)
            {
                return String.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }
            if (vessel.Captain != null)
            {
                return String.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            captain.AddVessel(vessel);
            vessel.Captain = captain;
            return String.Format(OutputMessages.SuccessfullyAssignCaptain, captain.FullName, vessel.Name);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attacker = this.vessels.FindByName(attackingVesselName);
            IVessel deffender = this.vessels.FindByName(defendingVesselName);

            if (attacker is null)
            {
                return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            else if (deffender is null)
            {
                return String.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }
            else if (attacker.ArmorThickness <= 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            else if (deffender.ArmorThickness <= 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }
            else
            {

                attacker.Attack(deffender);
                attacker.Captain.IncreaseCombatExperience();
                deffender.Captain.IncreaseCombatExperience();

                return String.Format(OutputMessages.SuccessfullyAttackVessel, deffender.Name, attacker.Name, deffender.ArmorThickness);
            }
        }

        public string CaptainReport(string captainFullName)
        {
            //ICaptain cap = this.captains.FirstOrDefault(x => x.FullName == captainFullName);
            ICaptain captain = this.captains.Where(c => c.Vessels.Count > 0).FirstOrDefault(c => c.FullName == captainFullName);
            return captain.Report();
        }

        public string HireCaptain(string fullName)
        {
            if (this.captains.Any(x => x.FullName == fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            this.captains.Add(new Captain(fullName));
            return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (this.vessels.FindByName(name) != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }

            IVessel vessel;

            if (vesselType == "Submarine")
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else
            {
                return String.Format(OutputMessages.InvalidVesselType, vesselType);
            }

            this.vessels.Add(vessel);
            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            if (vessel is null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }
            vessel.RepairVessel();
            return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            if (vessel is null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }

            string outputStr = string.Empty;
            if (vessel.GetType().Name == "Battleship")
            {
                (vessel as Battleship).ToggleSonarMode();
                outputStr = String.Format(OutputMessages.ToggleBattleshipSonarMode, vessel.Name);
            }
            if (vessel.GetType().Name == "Submarine")
            {
                (vessel as Submarine).ToggleSubmergeMode();
                outputStr = String.Format(OutputMessages.ToggleSubmarineSubmergeMode, vessel.Name);
            }
            return outputStr;
        }

        public string VesselReport(string vesselName)
        {
            return this.vessels.FindByName(vesselName).ToString();
        }
    }
}
