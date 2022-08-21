using System;

namespace fundamentalsLesson5
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            minutes += 30;

            if (minutes >= 60)
            {
                minutes = minutes - 60;
                hours += 1;
            }

            if (hours == 24)
            {
                hours = 0;
            }

            Console.Write($"{hours}:");

            if (minutes < 10)
            {
                Console.Write($"0{minutes}");
            }
            else
            {
                Console.Write($"{minutes}");
            }
        }
    }
}