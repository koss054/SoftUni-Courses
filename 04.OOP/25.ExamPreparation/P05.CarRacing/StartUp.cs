namespace CarRacing
{
    //using CarRacing.Models.Cars;
    using Core;
    using Core.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Car car = new TunedCar("Mitsubishi", "Lancer Evo 5", "12345678123456789", 100);

            //car.Drive();
            //System.Console.WriteLine(car.HorsePower);
            //car.Drive();
            //System.Console.WriteLine(car.HorsePower);
            //car.Drive();
            //System.Console.WriteLine(car.HorsePower);
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
