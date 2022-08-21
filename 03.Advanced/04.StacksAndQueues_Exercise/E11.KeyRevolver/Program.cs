using System;
using System.Collections.Generic;
using System.Linq;

namespace E11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());

            int[] bullets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] locks = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int intelligenceValue = int.Parse(Console.ReadLine());

            var currentBullets = new Stack<int>(bullets);
            var currentLocks = new Queue<int>(locks);

            int bulletsInBarrel = barrelSize;
            int bulletsShot = 0;

            while (currentBullets.Count != 0 && currentLocks.Count != 0)
            {
                int currentBullet = currentBullets.Pop();
                int currentLock = currentLocks.Peek();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    currentLocks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                bulletsInBarrel--;
                bulletsShot++;

                if (bulletsInBarrel == 0 && currentBullets.Count > 0)
                {
                    bulletsInBarrel = barrelSize;
                    Console.WriteLine("Reloading!");
                }
            }

            if (currentLocks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {currentLocks.Count}");
            }
            else
            {
                int moneyEarned = intelligenceValue - (bulletsShot * bulletPrice);
                Console.WriteLine($"{currentBullets.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
