using System;

namespace _07.RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string userString = Console.ReadLine();
            int timesRepeat = int.Parse(Console.ReadLine());

            Console.WriteLine(RepeatString(userString, timesRepeat));
        }

        private static string RepeatString (string enteredString, int timesRepeat)
        {
            string result = string.Empty;

            for (int i = 0; i < timesRepeat; i++)
            {
                result += enteredString;
            }

            return result;
        }
    }
}
