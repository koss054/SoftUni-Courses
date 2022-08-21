using System;

namespace _10.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());        //N
            int distance = int.Parse(Console.ReadLine());         //M
            int exhaustionFactor = int.Parse(Console.ReadLine()); //Y

            int pokedTargets = 0;
            double halfPower = pokePower * 0.5;

            while (pokePower >= distance)
            {
                pokedTargets++;
                pokePower -= distance;

                if (pokePower == halfPower && exhaustionFactor != 0)
                {
                    pokePower /= exhaustionFactor;
                }
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(pokedTargets);
        }
    }
}
