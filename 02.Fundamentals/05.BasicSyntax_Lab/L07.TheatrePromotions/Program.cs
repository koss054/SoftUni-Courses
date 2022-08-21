using System;

namespace fundamentalsLesson5
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int ticketPrice = 0;
            bool isNotValidAge = false;

            switch (day)
            {
                case "Weekday":
                    if (age >= 0 && age <= 18)
                    {
                        ticketPrice = 12;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        ticketPrice = 18;
                    }
                    else if (age >  64 && age <= 122)
                    {
                        ticketPrice = 12;
                    }
                    else
                    {
                        isNotValidAge = true;
                    }
                    break;
                case "Weekend":
                    if (age >= 0 && age <= 18)
                    {
                        ticketPrice = 15;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        ticketPrice = 20;
                    }
                    else if (age > 64 && age <= 122)
                    {
                        ticketPrice = 15;
                    }    
                    else
                    {
                        isNotValidAge = true;
                    }
                    break;
                case "Holiday":
                    if (age >= 0 && age <= 18)
                    {
                        ticketPrice = 5;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        ticketPrice = 12;
                    }
                    else if (age > 64 && age <= 122)
                    {
                        ticketPrice = 10;
                    }
                    else
                    {
                        isNotValidAge = true;
                    }
                    break;
            }

            if (isNotValidAge)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                Console.WriteLine($"{ticketPrice}$");
            }
        }
    }
}