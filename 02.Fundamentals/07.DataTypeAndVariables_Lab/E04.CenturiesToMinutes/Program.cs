using System;
using System.Numerics;

namespace fundamentalsLesson8
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            int enteredCenturies = int.Parse(Console.ReadLine());

            int years = enteredCenturies * 100;
            int days = (int)(years * 365.2422);
            int hours = days * 24;
            int minutes = hours * 60;

            Console.WriteLine($"{enteredCenturies} centuries = {years} years = {days:F0} days = {hours:F0} hours = {minutes:F0} minutes");
        }
    }
}