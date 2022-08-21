using System;
using System.Linq;
using System.Collections.Generic;

namespace L07.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            var parkingLot = new HashSet<string>();

            while (true)
            {
                var userInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (userInput[0] == "END")
                {
                    break;
                }

                string command = userInput[0];
                string carNumber = userInput[1];

                switch (command)
                {
                    case "IN":
                        parkingLot.Add(carNumber);
                        break;
                    case "OUT":
                        parkingLot.Remove(carNumber);
                        break;
                }
            }

            if (parkingLot.Count < 1)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var car in parkingLot)
                {
                    Console.WriteLine($"{car}");
                }
            }
        }
    }
}
