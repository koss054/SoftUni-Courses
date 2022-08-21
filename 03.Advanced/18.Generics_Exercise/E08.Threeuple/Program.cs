using System;

namespace _08.Threeuple
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
            string town = firstInput[3];

            string name = secondInput[0];
            int beerLitres = int.Parse(secondInput[1]);
            bool isDrunk = secondInput[2] == "drunk";

            string finalName = thirdInput[0];
            double accountBalance = double.Parse(thirdInput[1]);
            string bankName = thirdInput[2];

            var firstThreeuple = new Threeuple<string, string, string>(fullName, address, town);

            var secondThreeuple = new Threeuple<string, int, bool>(name, beerLitres, isDrunk);

            var thirdThreeuple = new Threeuple<string, double, string>(finalName, accountBalance, bankName);

            Console.WriteLine(firstThreeuple.ToString());
            Console.WriteLine(secondThreeuple.ToString());
            Console.WriteLine(thirdThreeuple.ToString());
        }
    }
}
