using System;
using System.Collections.Generic;
using System.Text;

namespace _06.SpeedRacing
{
    class Car
    {
        string model;
        double fuelAmount;
        double fuelConsumptionPerKilometer;
        double travelledDistance;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }

        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }

        public Car()
        {
            this.travelledDistance = 0;
        }
        public Car(string model, double fuelAmount,
            double fuelConsumptionFor1km)
            : this ()
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelConsumptionPerKilometer = fuelConsumptionFor1km;
        }

        public void Travel(double amountOfKm)
        {
            double currentFuelConsumption = amountOfKm * this.fuelConsumptionPerKilometer;

            if (currentFuelConsumption <= this.fuelAmount)
            {
                this.fuelAmount -= currentFuelConsumption;
                this.travelledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public string WhoAmI()
        {
            return $"{this.Model} {this.fuelAmount:F2} {this.travelledDistance}";
        }
    }
}
