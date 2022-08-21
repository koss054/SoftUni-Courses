using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int totalLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < totalLines; i++)
            {
                string[] userInput = Console.ReadLine().Split();

                string model = userInput[0];

                int engineSpeed = int.Parse(userInput[1]);
                int enginePower = int.Parse(userInput[2]);

                int cargoWeight = int.Parse(userInput[3]);
                string cargoType = userInput[4];

                double tire1Pressure = double.Parse(userInput[5]);
                int tire1Age = int.Parse(userInput[6]);
                double tire2Pressure = double.Parse(userInput[7]);
                int tire2Age = int.Parse(userInput[8]);
                double tire3Pressure = double.Parse(userInput[9]);
                int tire3Age = int.Parse(userInput[10]);
                double tire4Pressure = double.Parse(userInput[11]);
                int tire4Age = int.Parse(userInput[12]);

                var currentEngine = new Engine(engineSpeed, enginePower);
                var currentCargo = new Cargo(cargoWeight, cargoType);
                var currentTires = new Tires[]
                {
                    new Tires(tire1Pressure, tire1Age),
                    new Tires(tire2Pressure, tire2Age),
                    new Tires(tire3Pressure, tire3Age),
                    new Tires(tire4Pressure, tire4Age),
                };

                var currentCar = new Car(model, currentEngine, currentCargo, currentTires);
                cars.Add(currentCar);
            }

            string searchedCargoType = Console.ReadLine();

            foreach (Car car in cars)
            {
                switch (searchedCargoType)
                {
                    case "fragile":
                        bool areTiresValid = car.isTireUnderOne();

                        if (car.Cargo.CargoType == searchedCargoType && areTiresValid)
                        {
                            Console.WriteLine(car.WhoAmI());
                        }

                        break;
                    case "flammable":
                        bool isEngineValid = car.isEnginePowerful();

                        if (car.Cargo.CargoType == searchedCargoType && isEngineValid)
                        {
                            Console.WriteLine(car.WhoAmI());
                        }

                        break;
                }
            }
        }
    }
}
