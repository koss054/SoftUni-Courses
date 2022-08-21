using System;
using System.Collections.Generic;

namespace L07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var childrenNames = Console.ReadLine().Split();
            int enteredNumber = int.Parse(Console.ReadLine());
            var hotPotatoQueue = new Queue<string>(childrenNames);

            while (hotPotatoQueue.Count != 1)
            {
                for (int i = 1; i < enteredNumber; i++)
                {
                    hotPotatoQueue.Enqueue(hotPotatoQueue.Dequeue());
                }

                Console.WriteLine($"Removed {hotPotatoQueue.Dequeue()}");
            }

            Console.WriteLine($"Last is {hotPotatoQueue.Dequeue()}");
        }
    }
}
