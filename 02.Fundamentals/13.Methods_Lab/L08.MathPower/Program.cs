using System;

namespace _08.MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double enteredNumber = double.Parse(Console.ReadLine());
            int enteredPower = int.Parse(Console.ReadLine());

            Console.WriteLine(RaiseToPower(enteredNumber, enteredPower));
        }

        static double RaiseToPower(double number, int power)
        {
            double result = Math.Pow(number, power);

            return result;
        }
    }
}
