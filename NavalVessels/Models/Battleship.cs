using System;
using System.Collections.Generic;
using System.Text;

using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const int initialArmorTickness = 300;
        private bool sonarMode;
        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, initialArmorTickness)
        {
            this.SonarMode = false;
        }

        public bool SonarMode
        {
            get
            {
                return this.sonarMode;
            }
            private set
            {
                this.sonarMode = value;
            }
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < initialArmorTickness)
            {
                this.ArmorThickness = initialArmorTickness;
            }
        }

        public void ToggleSonarMode()
        {

            if (this.SonarMode == false)
            {
                this.SonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                this.SonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"*Sonar mode: {(this.SonarMode == true ? "ON" : "OFF")}");
            return sb.ToString().TrimEnd();
        }
    }
}
