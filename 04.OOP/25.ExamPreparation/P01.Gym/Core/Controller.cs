using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipmentRepository;
        private List<IGym> gyms;

        public Controller()
        {
            this.equipmentRepository = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            if (athleteType != "Boxer" && athleteType != "Weightlifter")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            IGym gym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            if ((athleteType == "Boxer" && gym.GetType().Name != "BoxingGym") ||
                (athleteType == "Weightlifter" && gym.GetType().Name != "WeightliftingGym"))
            {
                return OutputMessages.InappropriateGym;
            }

            if (athleteType == "Boxer")
            {
                gym.AddAthlete(new Boxer(athleteName, motivation, numberOfMedals));
            }
            else if (athleteType == "Weightlifter")
            {
                gym.AddAthlete(new Weightlifter(athleteName, motivation, numberOfMedals));
            }

            return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType != "BoxingGloves" && equipmentType != "Kettlebell")
            {
                throw new InvalidOperationException
                    (ExceptionMessages.InvalidEquipmentType);
            }

            IEquipment equipment;

            switch (equipmentType)
            {
                case "BoxingGloves":
                    equipment = new BoxingGloves();
                    this.equipmentRepository.Add(equipment);
                    break;
                case "Kettlebell":
                    equipment = new Kettlebell();
                    this.equipmentRepository.Add(equipment);
                    break;
            }

            return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType != "BoxingGym" && gymType != "WeightliftingGym")
            {
                throw new InvalidOperationException
                    (ExceptionMessages.InvalidGymType);
            }

            IGym gym;

            switch (gymType)
            {
                case "BoxingGym":
                    gym = new BoxingGym(gymName);
                    this.gyms.Add(gym);
                    break;
                case "WeightliftingGym":
                    gym = new WeightliftingGym(gymName);
                    this.gyms.Add(gym);
                    break;
            }

            return String.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            return String.Format(OutputMessages.EquipmentTotalWeight, gymName, gym.EquipmentWeight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipment = this.equipmentRepository.FindByType(equipmentType);

            if (equipment == null)
            {
                throw new InvalidOperationException(
                    String.Format
                    (ExceptionMessages.InexistentEquipment, 
                    equipmentType));
            }

            IGym gym = this.gyms.FirstOrDefault(x => x.Name == gymName);
            gym.AddEquipment(equipment);
            equipmentRepository.Remove(equipment);

            return String.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var gym in this.gyms)
            {
                sb.Append(gym.GymInfo());
                sb.AppendLine();
            }

            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            gym.Exercise();

            return String.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }
    }
}
