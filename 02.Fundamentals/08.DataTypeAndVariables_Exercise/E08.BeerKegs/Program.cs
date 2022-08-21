using System;

namespace _08.BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalKegs = int.Parse(Console.ReadLine());
            double biggestKegVolume = 0;
            string biggestKeg = string.Empty;

            
            for (int i = 0; i < totalKegs; i++)
            {
                string kegModel = Console.ReadLine();
                float kegRadius = float.Parse(Console.ReadLine());
                int kegHeight = int.Parse(Console.ReadLine());

                double currentKegVolume = (Math.PI) * (Math.Pow(kegRadius, 2)) * kegHeight;

                if (currentKegVolume > biggestKegVolume)
                {
                    biggestKegVolume = currentKegVolume;
                    biggestKeg = kegModel;
                }
            }

            Console.WriteLine($"{biggestKeg}");
        }
    }
}
