using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly AstronautRepository astronautRepo;
        private readonly PlanetRepository planetRepo;
        private List<IPlanet> exploredPlanets;

        public Controller()
        {
            this.astronautRepo = new AstronautRepository();
            this.planetRepo = new PlanetRepository();
            this.exploredPlanets = new List<IPlanet>();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = null;

            switch (type)
            {
                case "Biologist":
                    astronaut = new Biologist(astronautName);
                    break;

                case "Geodesist":
                    astronaut = new Geodesist(astronautName);
                    break;

                case "Meteorologist":
                    astronaut = new Meteorologist(astronautName);
                    break;

                default:
                    throw new InvalidOperationException("Astronaut type doesn't exists!");
            }

            this.astronautRepo.Add(astronaut);
            return $"Successfully added {astronaut.GetType().Name}: {astronaut.Name}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (string item in items)
            {
                planet.Items.Add(item);
            }

            this.planetRepo.Add(planet);
            return $"Successfully added Planet: {planet.Name}!";
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> viableForMissionAstronauts = this.astronautRepo.Models.Where(a => a.Oxygen > 60).ToList();

            if (viableForMissionAstronauts.Count == 0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }

            IPlanet planet = this.planetRepo.FindByName(planetName);
            IMission mission = new Mission();

            mission.Explore(planet, viableForMissionAstronauts);
            exploredPlanets.Add(planet);

            return $"Planet: {planet.Name} was explored! Exploration finished with {this.astronautRepo.Models.Where(a => !a.CanBreath).Count()} dead astronauts!";
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{exploredPlanets.Count} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (IAstronaut astronaut in this.astronautRepo.Models)
            {
                sb.AppendLine($"Name: { astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                sb.AppendLine($"Bag items: {(astronaut.Bag.Items.Count > 0 ? string.Join(", ", astronaut.Bag.Items) : "none")}");
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = this.astronautRepo.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }

            this.astronautRepo.Remove(astronaut);
            return $"Astronaut {astronaut.Name} was retired!";
        }
    }
}
