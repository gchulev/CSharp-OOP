using System;
using System.Collections.Generic;
using System.Text;

using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        private const double AggressiveMultiplier = 1.1;
        private const double StrictMultiplier = 1.2;

        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return "Race cannot be completed because both racers are not available!";
            }
            else if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }
            else if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            else
            {
                double racerOneMultiplier = 1;
                double racerTowMultiplier = 1;

                if (racerOne.RacingBehavior == "strict")
                {
                    racerOneMultiplier = StrictMultiplier;
                }
                else if (racerOne.RacingBehavior == "aggressive")
                {
                    racerOneMultiplier = AggressiveMultiplier;
                }

                if (racerTwo.RacingBehavior == "strict")
                {
                    racerTowMultiplier = StrictMultiplier;
                }
                else if (racerTwo.RacingBehavior == "aggressive")
                {
                    racerTowMultiplier = AggressiveMultiplier;
                }

                double racerOneChanceOfwinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneMultiplier;
                double racerTwoChanceOfWinning = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTowMultiplier;

                racerOne.Race();
                racerTwo.Race();

                string winnner;

                if (racerOneChanceOfwinning > racerTwoChanceOfWinning)
                {
                    winnner = racerOne.Username;
                }
                else
                {
                    winnner = racerTwo.Username;
                }
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {winnner} is the winner!";
            }
        }
    }
}
