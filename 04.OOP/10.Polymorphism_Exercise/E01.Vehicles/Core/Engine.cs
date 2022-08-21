using E01.Vehicles.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace E01.Vehicles.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] carInput = Console.ReadLine().Split();
            double carFuelQuantity = double.Parse(carInput[1]);
            double carLitresPerKm = double.Parse(carInput[2]);
            Car car = new Car(carFuelQuantity, carLitresPerKm);

            string[] truckInput = Console.ReadLine().Split();
            double truckFuelQuantity = double.Parse(truckInput[1]);
            double truckLitresPerKm = double.Parse(truckInput[2]);
            Truck truck = new Truck(truckFuelQuantity, truckLitresPerKm);

            int inputLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLines; i++)
            {
                string[] currentCommand = Console.ReadLine().Split();

                string action = currentCommand[0];
                string vehicle = currentCommand[1];
                double value = double.Parse(currentCommand[2]);

                if (action == "Drive")
                {
                    if (vehicle == "Car")
                    {
                        if (car.CanDrive(value))
                        {
                            car.Drive(value);
                            Console.WriteLine($"Car travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine("Car needs refueling");
                        }
                    }
                    else
                    {
                        if (truck.CanDrive(value))
                        {
                            truck.Drive(value);
                            Console.WriteLine($"Truck travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine("Truck needs refueling");
                        }
                    }
                }
                else
                {
                    if (vehicle == "Car")
                    {
                        car.Refuel(value);
                    }
                    else
                    {
                        truck.Refuel(value);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }
    }
}
