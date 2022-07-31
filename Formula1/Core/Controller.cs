using Formula1.Core.Contracts;
using Formula1.Factory;
using Formula1.Factory.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Repositories.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IPilot> _pilotRepository;
        private readonly IRepository<IRace> _raceRepository;
        private readonly IRepository<IFormulaOneCar> _formulaOneCarRepository;
        private readonly ICarFactory _carFactory;

        public Controller()
        {
            this._pilotRepository = new PilotRepository();
            this._raceRepository = new RaceRepository();
            this._formulaOneCarRepository = new FormulaOneCarRepository();
            this._carFactory = new CarFactory();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            var pilot = this._pilotRepository.Models.FirstOrDefault(p => p.FullName == pilotName);
            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            if (!this._formulaOneCarRepository.Models.Any(c => c.Model == carModel))
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            var car = this._formulaOneCarRepository.Models.FirstOrDefault(c => c.Model == carModel);
            pilot.AddCar(car);
            this._formulaOneCarRepository.Remove(car);
            return $"Pilot {pilot.FullName} will drive a {car.GetType().Name} {car.Model} car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var pilot = this._pilotRepository.Models.FirstOrDefault(p => p.FullName == pilotFullName);
            var race = this._raceRepository.Models.FirstOrDefault(r => r.RaceName == raceName);

            if (race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            bool pilotAlraedyInTheRace = race.Pilots.Contains(pilot);

            if (pilot == null || pilot.CanRace == false || pilotAlraedyInTheRace == true)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);
            return $"Pilot {pilot.FullName} is added to the {race.RaceName} race.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (this._formulaOneCarRepository.Models.Any(c => c.Model == model))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            var car = this._carFactory.ProduceCar(type, model, horsepower, engineDisplacement);
            this._formulaOneCarRepository.Add(car);
            return $"Car {type}, model {model} is created.";
        }

        public string CreatePilot(string fullName)
        {
            if (!this._pilotRepository.Models.Any(p => p.FullName == fullName))
            {
                this._pilotRepository.Add(new Pilot(fullName));
                return $"Pilot {fullName} is created.";
            }

            throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (this._raceRepository.Models.Any(r => r.RaceName == raceName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            var race = new Race(raceName, numberOfLaps);
            this._raceRepository.Add(race);
            return $"Race {raceName} is created.";
        }

        public string PilotReport()
        {
            var pilotsOrderedByWins = this._pilotRepository.Models.OrderByDescending(x => x.NumberOfWins);

            StringBuilder sb = new StringBuilder();

            foreach (Pilot pilot in pilotsOrderedByWins)
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            List<IRace> executedRaces = this._raceRepository.Models.Where(r => r.TookPlace == true).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (Race race in executedRaces)
            {
                sb.AppendLine(race.RaceInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            var race = this._raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            if (race.TookPlace == true)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            var orderedByDecendingRacers = race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps));
            var firstThreeRacers = orderedByDecendingRacers.Take(3).ToList();

            race.TookPlace = true;
            IPilot winnder = firstThreeRacers[0];
            winnder.WinRace();

            return $"Pilot {firstThreeRacers[0].FullName} wins the {race.RaceName} race.{Environment.NewLine}" +
                   $"Pilot {firstThreeRacers[1].FullName} is second in the {race.RaceName} race.{Environment.NewLine}" +
                   $"Pilot {firstThreeRacers[2].FullName} is third in the {race.RaceName} race.";
        }
    }
}
