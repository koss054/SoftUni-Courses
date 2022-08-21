using System;

namespace fundamentalsLesson6_2
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            double startingBalance = double.Parse(Console.ReadLine());
            double moneySpent = 0.0;

            while (true)
            {
                if (startingBalance == 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }

                double gamePrice = 0.0;

                string boughtGame = Console.ReadLine();

                if (boughtGame == "Game Time")
                {
                    Console.WriteLine($"Total spent: ${moneySpent:F2}. Remaining: ${startingBalance:F2}");
                    break;
                }

                switch (boughtGame)
                {
                    case "OutFall 4":
                        gamePrice = 39.99;

                        if (startingBalance >= gamePrice)
                        {
                            Console.WriteLine($"Bought {boughtGame}");
                        }
                        else
                        {
                            gamePrice = 0;
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "CS: OG":
                        gamePrice = 15.99;

                        if (startingBalance >= gamePrice)
                        {
                            Console.WriteLine($"Bought {boughtGame}");
                        }
                        else
                        {
                            gamePrice = 0;
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "Zplinter Zell":
                        gamePrice = 19.99;

                        if (startingBalance >= gamePrice)
                        {
                            Console.WriteLine($"Bought {boughtGame}");
                        }
                        else
                        {
                            gamePrice = 0;
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "Honored 2":
                        gamePrice = 59.99;

                        if (startingBalance >= gamePrice)
                        {
                            Console.WriteLine($"Bought {boughtGame}");
                        }
                        else
                        {
                            gamePrice = 0;
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "RoverWatch":
                        gamePrice = 29.99;

                        if (startingBalance >= gamePrice)
                        {
                            Console.WriteLine($"Bought {boughtGame}");
                        }
                        else
                        {
                            gamePrice = 0;
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "RoverWatch Origins Edition":
                        gamePrice = 39.99;

                        if (startingBalance >= gamePrice)
                        {
                            Console.WriteLine($"Bought {boughtGame}");
                        }
                        else
                        {
                            gamePrice = 0;
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        break;

                }

                startingBalance -= gamePrice;
                moneySpent += gamePrice;
            }
        }
    }
}