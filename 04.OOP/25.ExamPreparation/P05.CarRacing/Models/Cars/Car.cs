﻿using System;

using CarRacing.Models.Cars.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumptionPerRace;

        public Car(string make, string model, string vin, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            this.Make = make;
            this.Model = model;
            this.VIN = vin;
            this.HorsePower = horsePower;
            this.FuelAvailable = fuelAvailable;
            this.FuelConsumptionPerRace = fuelConsumptionPerRace;
        }

        public string Make
        {
            get
            {
                return this.make;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidCarMake);
                }

                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidCarModel);
                }

                this.model = value;
            }
        }

        public string VIN
        {
            get
            {
                return this.vin;
            }
            private set
            {
                if (value.Length != 17)
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidCarVIN);
                }

                this.vin = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidCarHorsePower);
                }

                this.horsePower = value;
            }
        }

        public double FuelAvailable
        {
            get
            {
                return this.fuelAvailable;
            }
            private set
            {
                this.fuelAvailable = value;

                if (this.fuelAvailable < 0)
                {
                    this.fuelAvailable = 0;
                }
            }
        }

        public double FuelConsumptionPerRace
        {
            get
            {
                return this.fuelConsumptionPerRace;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidCarFuelConsumption);
                }

                this.fuelConsumptionPerRace = value;
            }
        }

        public void Drive()
        {
            this.fuelAvailable -= this.fuelConsumptionPerRace;

            if (this.GetType().Name == "TunedCar")
            {
                this.horsePower = (int)Math.Round(this.horsePower * 0.97);
            }
        }
    }
}
