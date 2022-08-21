namespace E01.Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double litresPerKm)
            : base(fuelQuantity, litresPerKm)
        {
        }

        public override double LitresPerKm
            => base.LitresPerKm + 0.9;
    }
}
