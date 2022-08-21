using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerHand = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondPlayerHand = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            StartCardGame(firstPlayerHand, secondPlayerHand);
        }

        static void StartCardGame(List<int> firstPlayer, List<int> secondPlayer)
        {
            while (firstPlayer.Count > 0 && secondPlayer.Count > 0)
            {
                if (firstPlayer[0] > secondPlayer[0])
                {
                    firstPlayer.Add(firstPlayer[0]);
                    firstPlayer.Add(secondPlayer[0]);

                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                }
                else if (firstPlayer[0] < secondPlayer[0])
                {
                    secondPlayer.Add(secondPlayer[0]);
                    secondPlayer.Add(firstPlayer[0]);

                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                }
                else
                {
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                }
            }

            int winningHandSum = 0;

            if (firstPlayer.Count > 0)
            {
                winningHandSum = SumOfCardsInHand(firstPlayer);
                Console.WriteLine($"First player wins! Sum: {winningHandSum}");
            }
            else if (secondPlayer.Count > 0)
            {
                winningHandSum = SumOfCardsInHand(secondPlayer);
                Console.WriteLine($"Second player wins! Sum: {winningHandSum}");
            }
        }

        static int SumOfCardsInHand(List<int> currentHand)
        {
            int totalSum = 0;

            for (int i = 0; i < currentHand.Count; i++)
            {
                totalSum += currentHand[i];
            }

            return totalSum;
        }
    }
}
