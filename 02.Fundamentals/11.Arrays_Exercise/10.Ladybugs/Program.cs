using System;
using System.Linq;

namespace _10.Ladybugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] ladybugField = new int[fieldSize];

            string[] occupiedIndexes = Console.ReadLine().Split();

            for (int i = 0; i < occupiedIndexes.Length; i++)
            {
                int currentIndex = int.Parse(occupiedIndexes[i]);

                if (currentIndex >= 0 && currentIndex < fieldSize)
                {
                    ladybugField[currentIndex] = 1;
                }
            }

            string[] userCommands = Console.ReadLine().Split();

            while (userCommands[0] != "end")
            {
                int currentIndex = int.Parse(userCommands[0]);
                bool isFirst = true;

                while (currentIndex >= 0 
                    && currentIndex < fieldSize 
                    && ladybugField[currentIndex] != 0) 
                {
                    if (isFirst)
                    {
                        ladybugField[currentIndex] = 0;
                        isFirst = false;
                    }

                    string direction = userCommands[1];
                    int flightLength = int.Parse(userCommands[2]);

                    if (direction == "left")
                    {
                        currentIndex -= flightLength;

                        if (currentIndex >= 0 && currentIndex < fieldSize)
                        {
                            if (ladybugField[currentIndex] == 0)
                            {
                                ladybugField[currentIndex] = 1;
                                break;
                            }
                        }
                    }
                    else if (direction == "right")
                    {
                        currentIndex += flightLength;
                        
                        if (currentIndex >= 0 && currentIndex < fieldSize)
                        {
                            if (ladybugField[currentIndex] == 0)
                            {
                                ladybugField[currentIndex] = 1;
                                break;
                            }
                        }
                    }
                }

                userCommands = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", ladybugField));
        }
    }
}
