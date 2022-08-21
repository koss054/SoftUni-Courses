using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var sportCar = new SportCar(100, 100);
            sportCar.Drive(9);
            Console.WriteLine(sportCar.Fuel);
        }
    }
}
