using System;
using System.Linq;
using System.Collections.Generic;

namespace E07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalPumps = int.Parse(Console.ReadLine());
            var petrol = new Queue<int>();
            var distance = new Queue<int>();

            int currentFuel = 0;

            for (int i = 0; i < totalPumps; i++)
            {
                var input = Console.ReadLine().Split()
                    .Select(int.Parse).ToArray();
                petrol.Enqueue(input[0]);
                distance.Enqueue(input[1]);
            }

            for (int i = 0; i < totalPumps; i++)
            {
                currentFuel = petrol.Peek();

                for (int j = 0; j < totalPumps; j++)
                {
                    if (distance.Peek() <= currentFuel)
                    {
                        currentFuel -= distance.Peek();

                        if (j == totalPumps - 1)
                        {
                            Console.WriteLine(i);
                            return;
                        }
                    }
                    else
                    {
                        for (int k = j; k < totalPumps; k++)
                        {
                            petrol.Enqueue(petrol.Dequeue());
                            distance.Enqueue(distance.Dequeue());
                        }
                        break;
                    }

                    petrol.Enqueue(petrol.Dequeue());
                    distance.Enqueue(distance.Dequeue());
                    currentFuel += petrol.Peek();
                }

                petrol.Enqueue(petrol.Dequeue());
                distance.Enqueue(distance.Dequeue());
            }
        }
    }
}
