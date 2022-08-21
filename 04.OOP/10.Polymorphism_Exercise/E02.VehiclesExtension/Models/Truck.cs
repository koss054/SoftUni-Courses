namespace E02.VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double litresPerKm, double tankCapacity) 
            : base(fuelQuantity, litresPerKm, tankCapacity)
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
