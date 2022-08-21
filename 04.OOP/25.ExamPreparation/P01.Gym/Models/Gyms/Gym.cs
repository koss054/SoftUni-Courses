using System;
using System.Text;
using System.Collections.Generic;
using Gym.Utilities.Messages;
using Gym.Models.Gyms.Contracts;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using System.Linq;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private ICollection<IEquipment> equipment;
        private ICollection<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            this.equipment = new List<IEquipment>();
            this.athletes = new List<IAthlete>();

            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight
        {
            get { return this.Equipment.Select(x => x.Weight).Sum(); }
        }

        public ICollection<IEquipment> Equipment => this.equipment;

        public ICollection<IAthlete> Athletes => this.athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Athletes.Count == this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            this.Athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in this.Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            sb.Append("Athletes: ");

            if (this.Athletes.Count > 0)
            {
                sb.AppendLine(string.Join(", ", this.Athletes.Select(x => x.FullName)));
            }
            else
            {
                sb.AppendLine("No athletes");
            }

            sb.AppendLine($"Equipment total count: {this.Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {this.EquipmentWeight:F2} grams");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
            => this.Athletes.Remove(athlete);
    }
}
