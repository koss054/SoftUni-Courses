using System;

namespace _07.Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] secondInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] thirdInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string fullName = firstInput[0] + " " + firstInput[1];
            string address = firstInput[2];

            string name = secondInput[0];
            int beerLitres = int.Parse(secondInput[1]);

            int enteredInt = int.Parse(thirdInput[0]);
            double enteredDouble = double.Parse(thirdInput[1]);

            var firstTuple = new Tuple<string, string>(fullName, address);

            var secondTuple = new Tuple<string, int>(name, beerLitres);

            var thirdTuple = new Tuple<int, double>(enteredInt, enteredDouble);

            Console.WriteLine(firstTuple.ToString());
            Console.WriteLine(secondTuple.ToString());
            Console.WriteLine(thirdTuple.ToString());
        }
    }
}
