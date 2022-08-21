using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int numCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numCars; i++)
            {
                string[] userInput = Console.ReadLine().Split();

                string model = userInput[0];
                double fuelAmount = double.Parse(userInput[1]);
                double fuelConsumptionFor1km = double.Parse(userInput[2]);

                var currentCar = new Car(model, fuelAmount, fuelConsumptionFor1km);
                cars.Add(currentCar);
            }

            while (true)
            {
                string[] userInput = Console.ReadLine().Split();

                if (userInput[0] == "End")
                {
                    break;
                }

                string command = userInput[0];
                string carModel = userInput[1];
                double amountOfKm = double.Parse(userInput[2]);

                if (command == "Drive")
                {
                    foreach (var car in cars)
                    {
                        if (carModel == car.Model)
                        {
                            car.Travel(amountOfKm);
                        }
                    }
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.WhoAmI()); 
            }
        }
    }
}
