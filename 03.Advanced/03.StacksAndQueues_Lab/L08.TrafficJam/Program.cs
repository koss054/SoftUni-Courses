using System;
using System.Collections.Generic;

namespace L08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            var carsWaiting = new Queue<string>();

            int carsPassingOnGreen = int.Parse(Console.ReadLine());
            int passedCarsCounter = 0;

            while (true)
            {
                string userInput = Console.ReadLine();

                if (userInput == "end")
                {
                    Console.WriteLine($"{passedCarsCounter} cars passed the crossroads.");
                    return;
                }

                if (userInput == "green")
                {
                    for (int i = 0; i < carsPassingOnGreen; i++)
                    {
                        if (carsWaiting.Count != 0)
                        {
                            Console.WriteLine($"{carsWaiting.Dequeue()} passed!");
                            passedCarsCounter++;
                        }
                    }
                }
                else
                {
                    carsWaiting.Enqueue(userInput);
                }
            }
        }
    }
}
