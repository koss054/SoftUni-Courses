using System;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagonNumber = int.Parse(Console.ReadLine());
            int[] wagonPassengers = new int[wagonNumber];
            int totalPassengers = 0;

            for (int i = 0; i < wagonNumber; i++)
            {
                int currentWagonPassegners = int.Parse(Console.ReadLine());
                wagonPassengers[i] = currentWagonPassegners;
                totalPassengers += currentWagonPassegners;
            }

            for (int i = 0; i < wagonPassengers.Length; i++)
            {
                Console.Write($"{wagonPassengers[i]} ");
            }

            Console.WriteLine($"\n{totalPassengers}");
        }
    }
}
