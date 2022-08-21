using System;
using System.Linq;
using System.Collections.Generic;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var tiresInfo = new Dictionary<int, Tire[]>();
            var engineInfo = new Dictionary<int, Engine>();
            var carList = new List<Car>();

            int counter = 0;

            while (true)
            {
                string userInput = Console.ReadLine();

                if (userInput == "No more tires")
                {
                    break;
                }

                double[] tireInformation = userInput
                    .Split()
                    .Select(double.Parse)
                    .ToArray();

                var tempTire = new Tire[4]
                {
                    new Tire((int)tireInformation[0], tireInformation[1]),
                    new Tire((int)tireInformation[2], tireInformation[3]),
                    new Tire((int)tireInformation[4], tireInformation[5]),
                    new Tire((int)tireInformation[6], tireInformation[7]),
                };

                tiresInfo[counter] = tempTire;
                counter++;
            }

            counter = 0;

            while (true)
            {
                string userInput = Console.ReadLine();

                if (userInput == "Engines done")
                {
                    break;
                }

                double[] engineInformation = userInput
                    .Split()
                    .Select(double.Parse)
                    .ToArray();

                engineInfo[counter] = new Engine((int)engineInformation[0], engineInformation[1]);
                counter++;
            }

            while (true)
            {
                string[] userInput = Console.ReadLine().Split();

                if (userInput[0] == "Show")
                {
                    break;
                }

                string make = userInput[0];
                string model = userInput[1];
                int year = int.Parse(userInput[2]);
                double fuelQuantity = double.Parse(userInput[3]);
                double fuelConsumption = double.Parse(userInput[4]);
                int engineIndex = int.Parse(userInput[5]);
                int tiresIndex = int.Parse(userInput[6]);

                Engine tempEngine = engineInfo[engineIndex];
                Tire[] tempTires = tiresInfo[tiresIndex];
                Car tempCar = new Car(make, model, year, 
                    fuelQuantity, fuelConsumption, tempEngine, tempTires);

                carList.Add(tempCar);
            }

            foreach (var car in carList)
            {
                if (car.Year >= 2017 && car.Engine.HorsePower > 330)
                {
                    Console.WriteLine(car.WhoAmI()); 
                    car.Drive(20);
                }
            }
        }
    }
}
