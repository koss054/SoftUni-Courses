using System;
using System.Linq;
using System.Collections.Generic;

namespace _08.CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            var engines = new List<Engine>();
            var cars = new List<Car>();

            int totalEngines = int.Parse(Console.ReadLine());

            for (int i = 0; i < totalEngines; i++)
            {
                string[] engineDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string engineModel = engineDetails[0];
                int enginePower = int.Parse(engineDetails[1]);

                if (engineDetails.Length == 2)
                {
                    var currentEngine = new Engine(engineModel, enginePower);
                    engines.Add(currentEngine);
                }
                else if (engineDetails.Length == 3)
                {
                    string engineDisplacementOrEfficiency = engineDetails[2];

                    if (int.TryParse(engineDisplacementOrEfficiency, out int engineDisplacement))
                    {
                        var currentEngine = new Engine(engineModel, enginePower, engineDisplacement);
                        engines.Add(currentEngine);
                    }
                    else
                    {
                       var currentEngine = new Engine(engineModel, enginePower, engineDisplacementOrEfficiency);
                       engines.Add(currentEngine);

                    }
                }
                else if (engineDetails.Length == 4)
                {
                    int engineDisplacement = int.Parse(engineDetails[2]);
                    string engineEfficiency = engineDetails[3];
                    var currentEngine = new Engine(engineModel, enginePower, engineDisplacement, engineEfficiency);
                    engines.Add(currentEngine);
                }

            }

            int totalCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < totalCars; i++)
            {
                string[] carDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = carDetails[0];
                string carEngineModel = carDetails[1];
                Engine carEngine = new Engine();

                foreach (var engine in engines)
                {
                    if (engine.Model == carEngineModel)
                    {
                        carEngine = engine;
                        break;
                    }
                }

                if (carDetails.Length == 2)
                {
                    var currentCar = new Car(carModel, carEngine);
                    cars.Add(currentCar);
                }
                else if (carDetails.Length == 3)
                {
                    string carWeightOrColor = carDetails[2];

                    if (int.TryParse(carWeightOrColor, out int carWeight))
                    {
                        var currentCar = new Car(carModel, carEngine, carWeight);
                        cars.Add(currentCar);
                    }
                    else
                    {
                        var currentCar = new Car(carModel, carEngine, carWeightOrColor);
                        cars.Add(currentCar);
                    }
                }
                else if (carDetails.Length == 4)
                {
                    int carWeight = int.Parse(carDetails[2]);
                    string carColor = carDetails[3];
                    var currentCar = new Car(carModel, carEngine, carWeight, carColor);
                    cars.Add(currentCar);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}
