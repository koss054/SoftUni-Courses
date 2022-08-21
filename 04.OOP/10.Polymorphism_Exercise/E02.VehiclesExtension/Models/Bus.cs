namespace E02.VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double litresPerKm, double tankCapacity) : base(fuelQuantity, litresPerKm, tankCapacity)
        {
        }

        public override double LitresPerKm
            => this.IsEmpty
            ? base.LitresPerKm
            : base.LitresPerKm + 1.4;
    }
}
