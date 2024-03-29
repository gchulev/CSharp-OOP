﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories;

namespace EasterRaces.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly DriverRepository drivers;
        private readonly CarRepository cars;
        private readonly RaceRepository races;
        public ChampionshipController()
        {
            this.drivers = new DriverRepository();
            this.cars = new CarRepository();
            this.races = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = this.drivers.Models.FirstOrDefault(d => d.Name == driverName);
            ICar car = this.cars.Models.FirstOrDefault(c => c.Model == carModel);

            if (driver is null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            if (car is null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            driver.AddCar(car);

            return $"Driver {driver.Name} received car {car.Model}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = this.races.GetByName(raceName);
            IDriver driver = this.drivers.GetByName(driverName);

            if (race is null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (driver is null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            race.AddDriver(driver);

            return $"Driver {driver.Name} added in {race.Name} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.cars.GetByName(model) != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }

            ICar car;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }
            else
            {
                throw new InvalidOperationException("Invalid car type!");
            }

            this.cars.Add(car);

            return $"{car.GetType().Name} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            if (this.drivers.Models.Any(d => d.Name == driverName))
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }

            IDriver driver = new Driver(driverName);
            this.drivers.Add(driver);

            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            if (this.races.GetByName(name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }

            IRace race = new Race(name, laps);
            this.races.Add(race);

            return $"Race {race.Name} is created.";
        }

        public string StartRace(string raceName)
        {
            IRace race = this.races.GetByName(raceName);

            if (race is null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {race.Name} cannot start with less than 3 participants.");
            }

            var fastestTreeDrivers = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).Take(3).ToList();

            var sb = new StringBuilder();

            sb.AppendLine($"Driver {fastestTreeDrivers[0].Name} wins {race.Name} race.");
            sb.AppendLine($"Driver {fastestTreeDrivers[1].Name} is second in {race.Name} race.");
            sb.AppendLine($"Driver {fastestTreeDrivers[2].Name} is third in {race.Name} race.");

            this.races.Remove(race);

            return sb.ToString().TrimEnd();

        }
    }
}
