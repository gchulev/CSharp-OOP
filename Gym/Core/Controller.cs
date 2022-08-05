using System;
using System.Collections.Generic;
using System.Text;

using Gym.Core.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using System.Linq;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Athletes;

namespace Gym.Core
{
    public class Controller : IController
    {
        private readonly EquipmentRepository equipment;
        private readonly List<IGym> gyms;

        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals) //another lame implementation without factory
        {
            if (athleteType != "Boxer" && athleteType != "Weightlifter")
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }

            IAthlete athlete = null;
            IGym gym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            if (athleteType == "Boxer" && gym.GetType().Name == "BoxingGym")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
                gym.AddAthlete(athlete);

                return $"Successfully added {athleteType} to {gymName}.";
            }
            else if (athleteType == "Weightlifter" && gym.GetType().Name == "WeightliftingGym")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                gym.AddAthlete(athlete);

                return $"Successfully added {athleteType} to {gymName}.";
            }
            else
            {
                return $"The gym is not appropriate.";
            }
        }

        public string AddEquipment(string equipmentType) // Lame implementation... should be refactored if there is time. Implement factory!!!
        {

            if (equipmentType == "BoxingGloves")
            {
                IEquipment boxingGloves = new BoxingGloves();
                this.equipment.Add(boxingGloves);

                return $"Successfully added {equipmentType}.";
            }
            else if (equipmentType == "Kettlebell")
            {
                IEquipment kettleBell = new Kettlebell();
                this.equipment.Add(kettleBell);

                return $"Successfully added {equipmentType}.";
            }
            else
            {
                throw new InvalidOperationException("Invalid equipment type.");
            }
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym = null;

            if (gymType != "BoxingGym" && gymType != "WeightliftingGym")
            {
                throw new InvalidOperationException("Invalid gym type.");
            }
            else if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }

            this.gyms.Add(gym);
            return $"Successfully added {gymType}.";
        }

        public string EquipmentWeight(string gymName)
        {
            var currentGym = this.gyms.FirstOrDefault(g => g.Name == gymName);

            return $"The total weight of the equipment in the gym {currentGym.Name} is {currentGym.EquipmentWeight:f2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType) // Another lame implementation... Factory really needed!!!
        {
            IGym currentGym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            if (this.equipment.FindByType(equipmentType) is null)
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }

            IEquipment currentEquipment = null;

            if (equipmentType == "BoxingGloves")
            {
                currentEquipment = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                currentEquipment = new Kettlebell();
            }
            currentGym.AddEquipment(currentEquipment);
            this.equipment.Remove(currentEquipment);

            return $"Successfully added {equipmentType} to {gymName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IGym gym in this.gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().Trim();
        }

        public string TrainAthletes(string gymName)
        {
            var currentGym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            foreach (IAthlete athlete in currentGym.Athletes)
            {
                athlete.Exercise();
            }

            return $"Exercise athletes: {currentGym.Athletes.Count}.";
        }
    }
}
