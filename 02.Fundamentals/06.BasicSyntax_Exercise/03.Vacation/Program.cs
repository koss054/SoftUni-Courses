using System;

namespace fundamentalsLesson6
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            int numPeople = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string weekDay = Console.ReadLine();

            double price = 0.0;
            double totalPrice = 0.0;

            switch (groupType)
            {
                case "Students":
                    if (weekDay == "Friday")
                    {
                        price = 8.45;
                    }
                    else if (weekDay == "Saturday")
                    {
                        price = 9.80;
                    }
                    else if (weekDay == "Sunday")
                    {
                        price = 10.46;
                    }

                    totalPrice = price * numPeople;

                    if (numPeople >= 30)
                    {
                        totalPrice -= totalPrice * 0.15; 
                    }
                    break;
                case "Business":
                    if (weekDay == "Friday")
                    {
                        price = 10.90;
                    }
                    else if (weekDay == "Saturday")
                    {
                        price = 15.60;
                    }
                    else if (weekDay == "Sunday")
                    {
                        price = 16;
                    }
                  

                    if (!(numPeople >= 100))
                    {
                        totalPrice = price * numPeople;
                    }
                    else
                    {
                        totalPrice = price * (numPeople - 10);
                    }
                    break;
                case "Regular":
                    if (weekDay == "Friday")
                    {
                        price = 15;
                    }
                    else if (weekDay == "Saturday")
                    {
                        price = 20;
                    }
                    else if (weekDay == "Sunday")
                    {
                        price = 22.50;
                    }

                    totalPrice = price * numPeople;

                    if (numPeople >= 10 && numPeople <= 20)
                    {
                       totalPrice -= totalPrice * 0.05;
                    }
                    break;
            }
            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}