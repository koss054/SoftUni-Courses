using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numberOfPassengersInWagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int maxWagonCapacity = int.Parse(Console.ReadLine());

            string[] userInput = Console.ReadLine()
                .Split()
                .ToArray();

            while (userInput[0] != "end")
            {
                if (userInput[0] == "Add")
                {
                    if (int.Parse(userInput[1]) <= maxWagonCapacity)
                    {
                        int addedWagonPassengers = int.Parse(userInput[1]);
                        numberOfPassengersInWagons.Add(addedWagonPassengers);
                    }
                }
                else
                {
                    numberOfPassengersInWagons = FindASingleWagon(userInput, maxWagonCapacity, numberOfPassengersInWagons);
                }


                userInput = Console.ReadLine()
                    .Split()
                    .ToArray();
            }

            Console.WriteLine(string.Join(" ", numberOfPassengersInWagons));
        }

        static List<int> FindASingleWagon(string[] addedPassengers, int wagonLimit,List<int> currentList)
        {
            List<int> tempList = currentList;
            int numberOfAddedPassengers = int.Parse(addedPassengers[0]);

            for (int i = 0; i < currentList.Count; i++)
            {
                int currentWagonToLimit = wagonLimit - currentList[i];

                if (numberOfAddedPassengers <= currentWagonToLimit)
                {
                    tempList[i] += numberOfAddedPassengers;
                    break;
                }
            }

            return tempList;
        }
    }
}
