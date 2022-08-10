using System;
using System.Collections.Generic;
using System.Text;

using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int DRIVING_EXP = 10;
        private const string DRIVING_BEHAVIOUR = "aggressive";
        public StreetRacer(string username, ICar car)
            : base(username, DRIVING_BEHAVIOUR, DRIVING_EXP, car)
        {
        }

        public override void Race()
        {
            this.Car.Drive();
            this.DrivingExperience += 5;
        }
    }
}
