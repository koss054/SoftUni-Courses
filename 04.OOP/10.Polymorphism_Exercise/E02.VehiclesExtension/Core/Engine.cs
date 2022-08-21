using E02.VehiclesExtension.Contracts;
using E02.VehiclesExtension.Models;
using System;

namespace E02.VehiclesExtension.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carInfo[1]);
            double carLitresPerKm = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);

            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckLitresPerKm = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);

            double busFuelQuantity = double.Parse(busInfo[1]);
            double busLitresPerKm = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);

            Car car = new Car(carFuelQuantity, carLitresPerKm, carTankCapacity);
            Truck truck = new Truck(truckFuelQuantity, truckLitresPerKm, truckTankCapacity);
            Bus bus = new Bus(busFuelQuantity, busLitresPerKm, busTankCapacity);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] command = Console.ReadLine().Split();

                    string action = command[0];
                    string vehicle = command[1];
                    double value = double.Parse(command[2]);

                    IVehicle currentVehicle = GetVehicleType(car, truck, bus, vehicle);

                    if (action == "Drive")
                    {
                        if (currentVehicle.CanDrive(value))
                        {
                            currentVehicle.Drive(value);
                            Console.WriteLine($"{vehicle} travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine($"{vehicle} needs refueling");
                        }
                    }
                    else if (action == "DriveEmpty")
                    {
                        bus.IsEmpty = true;

                        if (currentVehicle.CanDrive(value))
                        {
                            bus.Drive(value);
                            Console.WriteLine($"{vehicle} travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine($"{vehicle} needs refueling");
                        }

                        bus.IsEmpty = false;
                    }
                    else
                    {
                        if (currentVehicle.CanRefuel(value))
                        {
                            currentVehicle.Refuel(value);
                        }
                        else
                        {
                            Console.WriteLine($"Cannot fit {value} fuel in the tank");
                        }
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }

        private static IVehicle GetVehicleType(Car car, Truck truck, Bus bus, string vehicle)
        {
            if (vehicle == "Car")
            {
                return car;
            }
            else if (vehicle == "Truck")
            {
                return truck;
            }

            return bus;
        }
    }
}
