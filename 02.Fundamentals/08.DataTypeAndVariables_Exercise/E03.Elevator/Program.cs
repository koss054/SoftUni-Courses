using System;

namespace _03.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int elevatorCapacity = int.Parse(Console.ReadLine());

            decimal numberOfCourses = (decimal) numberOfPeople / (decimal) elevatorCapacity;
            numberOfCourses = Math.Ceiling(numberOfCourses);
            

            Console.WriteLine($"{numberOfCourses}");
        }
    }
}
