using System;

namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            int enteredDay = int.Parse(Console.ReadLine());

            if (enteredDay >= 1 && enteredDay <= 7)
            {
                Console.WriteLine(daysOfWeek[enteredDay - 1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
