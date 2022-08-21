using System;
using System.Text;

using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;

        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            this.Username = username;
            this.RacingBehavior = racingBehavior;
            this.DrivingExperience = drivingExperience;
            this.Car = car;
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidRacerName);
                }

                this.username = value;
            }
        }

        public string RacingBehavior
        {
            get
            {
                return this.racingBehavior;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidRacerBehavior);
                }

                this.racingBehavior = value;
            }
        }

        public int DrivingExperience
        {
            get
            {
                return this.drivingExperience;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidRacerDrivingExperience);
                }

                this.drivingExperience = value;
            }
        }

        public ICar Car
        {
            get
            {
                return this.car;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidRacerCar);
                }

                this.car = value;
            }
        }

        public bool IsAvailable()
        {
            if (this.Car.FuelAvailable - this.Car.FuelConsumptionPerRace > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Race()
        {
            this.Car.Drive();

            if (this.GetType().Name == "ProfessionalRacer")
            {
                this.drivingExperience += 10;
            }

            if (this.GetType().Name == "StreetRacer")
            {
                this.drivingExperience += 5;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}: {this.username}");
            sb.AppendLine($"--Driving behavior: {this.racingBehavior}");
            sb.AppendLine($"--Driving experience: {this.drivingExperience}");
            sb.AppendLine($"--Car: {this.car.Make} {this.car.Model} ({this.car.VIN})");

            return sb.ToString().TrimEnd();
        }
    }
}
