using System;

namespace E04.VacationBooksList
{
    class Program
    {
        static void Main(string[] args)
        {
            int bookPages = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int daysToReadBook = int.Parse(Console.ReadLine());

            int hoursNeeded = (bookPages / pagesPerHour);
            int daysNeeded = hoursNeeded / daysToReadBook;

            Console.WriteLine(daysNeeded);
        }
    }
}
