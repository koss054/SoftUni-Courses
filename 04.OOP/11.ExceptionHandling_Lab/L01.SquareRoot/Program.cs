using System;

namespace L01.SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double number = int.Parse(Console.ReadLine());

                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                number = Math.Sqrt(number);
                Console.WriteLine(number);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid number.");
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
