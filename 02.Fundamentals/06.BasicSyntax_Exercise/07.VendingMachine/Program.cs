using System;

namespace fundamentalsLesson6
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            double balance = 0;
            bool hasEnded = false;

            while (true)
            {
                string userInput = Console.ReadLine();

                if (userInput == "Start")
                {
                    break;
                }

                double addedCoins = double.Parse(userInput);

                switch (addedCoins)
                {
                    case 0.1:
                    case 0.2:
                    case 0.5:
                    case 1:
                    case 2:
                        balance += addedCoins;
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {addedCoins}");
                        break;
                }
            }

            while (!hasEnded)
            {
                string purchasedProduct = Console.ReadLine();

                switch (purchasedProduct)
                {
                    case "Nuts":
                        if (balance >= 2.0)
                        {
                            balance -= 2.0;
                            Console.WriteLine("Purchased nuts");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Water":
                        if (balance >= 0.7)
                        {
                            balance -= 0.7;
                            Console.WriteLine("Purchased water");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Crisps":
                        if (balance >= 1.5)
                        {
                            balance -= 1.5;
                            Console.WriteLine("Purchased crisps");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Soda":
                        if (balance >= 0.8)
                        {
                            balance -= 0.8;
                            Console.WriteLine("Purchased soda");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Coke":
                        if (balance >= 1.0)
                        {
                            balance -= 1.0;
                            Console.WriteLine("Purchased coke");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "End":
                        Console.WriteLine($"Change: {balance:F2}");
                        hasEnded = true;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }
            }
        }
    }
}