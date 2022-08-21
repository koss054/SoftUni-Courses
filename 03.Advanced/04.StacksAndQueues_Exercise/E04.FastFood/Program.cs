using System;
using System.Linq;
using System.Collections.Generic;

namespace E04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());
            var orderedFood = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            var orderQueue = new Queue<int>(orderedFood);
            int sum = 0;

            Console.WriteLine(orderQueue.Max());

            while (orderQueue.Count > 0)
            {
                int firstOrder = orderQueue.Peek();
                sum += firstOrder;

                if (sum <= quantityOfFood)
                {
                    orderQueue.Dequeue();
                }
                else
                {
                    var ordersLeft = orderQueue.ToArray();

                    Console.WriteLine("Orders left: " + string.Join(" ", ordersLeft));
                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}
