using System;
using System.Collections.Generic;

namespace L06.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientsQueue = new Queue<string>();

            while (true)
            {
                string userInput = Console.ReadLine();

                if (userInput == "End")
                {
                    int clientsLeft = clientsQueue.Count;
                    Console.WriteLine($"{clientsLeft} people remaining.");
                    return;
                }

                if (userInput == "Paid")
                {
                    while (clientsQueue.Count != 0)
                    {
                        Console.WriteLine(clientsQueue.Dequeue());
                    }
                }
                else
                {
                    clientsQueue.Enqueue(userInput);
                }
            }
        }
    }
}
