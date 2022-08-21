namespace E01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double litresPerKm) 
            : base(fuelQuantity, litresPerKm)
        {
        }

        public override double LitresPerKm
            => base.LitresPerKm + 1.6;

        public override void Refuel(double amount)
        {
            amount *= 0.95;
            base.Refuel(amount);
        }
    }
}
