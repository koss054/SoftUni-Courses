using System;

namespace E09.FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine()) / 100;

            int aquariumVolume =
                length * width * height;

            double aquariumLitres =
                (double)aquariumVolume / 1000;

            double neededLitres =
                aquariumLitres *
                (1 - percentage);

            Console.WriteLine(neededLitres);
        }
    }
}
