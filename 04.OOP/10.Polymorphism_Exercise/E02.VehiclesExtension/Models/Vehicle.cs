using E02.VehiclesExtension.Contracts;
using System;

namespace E02.VehiclesExtension.Models
{
    public abstract class Vehicle : IVehicle
    {
        double fuelQuantity;

        protected Vehicle(double fuelQuantity, double litresPerKm, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.LitresPerKm = litresPerKm;
        }

        public double FuelQuantity 
        { 
            get 
            {
                return fuelQuantity; 
            }
            private set 
            { 
                if (value > this.TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public virtual double LitresPerKm { get; protected set; }

        public double TankCapacity { get; private set; }

        public bool IsEmpty { get; set; }

        public bool CanDrive(double km)
            => this.FuelQuantity - (km * this.LitresPerKm) >= 0;

        public bool CanRefuel(double amount)
            => this.FuelQuantity + amount <= this.TankCapacity;

        public void Drive(double km)
        {
            if (CanDrive(km))
            {
                this.FuelQuantity -= (km * LitresPerKm);
            }
        }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (CanRefuel(amount))
            {
                this.FuelQuantity += amount;
            }
            else
            {
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
            }
        }
    }
}
