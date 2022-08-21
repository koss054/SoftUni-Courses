namespace E02.VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double litresPerKm, double tankCapacity) : base(fuelQuantity, litresPerKm, tankCapacity)
        {
        }

        public override double LitresPerKm
            => base.LitresPerKm + 0.9;
    }
}
