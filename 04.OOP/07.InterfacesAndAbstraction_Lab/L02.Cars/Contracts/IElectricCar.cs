namespace Cars.Contracts
{
    public interface IElectricCar : ICar
    {
        int Battery { get; set; }
    }
}
