namespace E01.Vehicles.Models
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double litresPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.LitresPerKm = litresPerKm;
        }

        public double FuelQuantity { get; set; }

        public virtual double LitresPerKm { get; set; }

        public bool CanDrive(double km)
            => this.FuelQuantity - (km * this.LitresPerKm) >= 0;

        public void Drive(double km)
        {
            if (CanDrive(km))
            {
                this.FuelQuantity -= (km * LitresPerKm);
            }
        }

        public virtual void Refuel(double amount)
        {
            this.FuelQuantity += amount;
        }
    }
}
