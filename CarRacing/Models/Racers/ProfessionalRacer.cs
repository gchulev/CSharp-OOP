using System;
using System.Collections.Generic;
using System.Text;

using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int DRIVING_EXP = 30;
        private const string RACING_BEHAVIOUR = "strict";
        public ProfessionalRacer(string username, ICar car)
            : base(username, RACING_BEHAVIOUR, DRIVING_EXP, car)
        {
        }

        public override void Race()
        {
            this.Car.Drive();
            this.DrivingExperience += 10;
        }
    }
}
