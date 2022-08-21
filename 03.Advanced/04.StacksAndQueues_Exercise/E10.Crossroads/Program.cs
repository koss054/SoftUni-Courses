using System;
using System.Linq;
using System.Collections.Generic;

namespace E10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            var carsQueue = new Queue<string>();

            int counter = 0;

            while (true)
            {
                string car = Console.ReadLine();

                int greenLight = greenLightSeconds;
                int freeWindow = freeWindowDuration;

                if (car == "END")
                {
                    Console.WriteLine("Everyone is safe.");
                    Console.WriteLine($"{counter} total cars passed the crossroads.");
                    return;
                }

                if (car == "green")
                {
                    while (greenLight > 0 && carsQueue.Count != 0)
                    {
                        string currentCar = carsQueue.Dequeue();
                        greenLight -= currentCar.Count();

                        if (greenLight >= 0)
                        {
                            counter++;
                        }
                        else
                        {
                            freeWindow += greenLight;

                            if (freeWindow < 0)
                            {
                                Console.WriteLine($"A crash happened!");
                                Console.WriteLine($"{currentCar} was hit at {currentCar[currentCar.Length + freeWindow]}.");
                                return;
                            }

                            counter++;
                        }
                    }
                }
                else
                {
                    carsQueue.Enqueue(car);
                }
            }
        }
    }
}
