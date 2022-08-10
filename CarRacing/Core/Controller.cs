using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Repositories.Contracts;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private readonly IRepository<ICar> cars;
        private readonly IRepository<IRacer> racers;
        private readonly IMap map;

        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar currentCar;

            if (type == "SuperCar")
            {
                currentCar = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == "TunedCar")
            {
                currentCar = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException("Invalid car type!");
            }

            this.cars.Add(currentCar);
            return $"Successfully added car {currentCar.Make} {currentCar.Model} ({currentCar.VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            IRacer currentRacer;
            ICar foundCar = this.cars.FindBy(carVIN);

            if (foundCar is null)
            {
                throw new ArgumentException("Car cannot be found!");
            }
            else if (type == "ProfessionalRacer")
            {
                currentRacer = new ProfessionalRacer(username, foundCar);
            }
            else if (type == "StreetRacer")
            {
                currentRacer = new StreetRacer(username, foundCar);
            }
            else
            {
                throw new ArgumentException("Invalid racer type!");
            }

            this.racers.Add(currentRacer);
            return $"Successfully added racer {currentRacer.Username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = this.racers.FindBy(racerOneUsername);
            IRacer racerTwo = this.racers.FindBy(racerTwoUsername);

            if (racerOne is null)
            {
                throw new ArgumentException($"Racer {racerOneUsername} cannot be found!");
            }
            else if (racerTwo is null)
            {
                throw new ArgumentException($"Racer {racerTwoUsername} cannot be found!");
            }

            return this.map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IRacer racer in this.racers.Models.OrderByDescending(r => r.DrivingExperience).ThenBy(r => r.Username))
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
