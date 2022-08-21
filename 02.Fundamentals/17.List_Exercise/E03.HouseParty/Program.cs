using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guestNamesList = new List<string>();

            int totalNumberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < totalNumberOfCommands; i++)
            {
                string[] guestNameAndCommand = Console.ReadLine().Split();

                string currentGuestName = guestNameAndCommand[0];
                string currentCommand = guestNameAndCommand[2];

                if (currentCommand == "going!")
                {
                    CommandGoingToParty(currentGuestName, guestNamesList);
                }
                else if (currentCommand == "not")
                {

                    CommandNotGointToParty(currentGuestName, guestNamesList);
                }
            }

            for (int i = 0; i < guestNamesList.Count; i++)
            {
                Console.WriteLine(guestNamesList[i]);
            }
        }

        static void CommandGoingToParty(string guestName, List<string> currentList)
        {
            if (currentList.Count == 0)
            {
                currentList.Add(guestName);
            }
            else
            {
                bool isOnList = false;

                for (int i = 0; i < currentList.Count; i++)
                {
                    if (guestName == currentList[i])
                    {
                        isOnList = true;
                        break;
                    }
                }

                if (!isOnList)
                {
                    currentList.Add(guestName);
                }
                else
                {
                    Console.WriteLine($"{guestName} is already in the list!");
                }
            }
        }

        static void CommandNotGointToParty(string guestName, List<string> currentList)
        {
            bool isOnList = false;

            for (int i = 0; i < currentList.Count; i++)
            {
                if (guestName == currentList[i])
                {
                    isOnList = true;
                }
            }

            if (isOnList)
            {
                currentList.Remove(guestName);
            }
            else
            {
                Console.WriteLine($"{guestName} is not in the list!");
            }
        }
    }
}
