using System;
using System.Linq;
using System.Collections.Generic;

namespace E06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int totalColors = int.Parse(Console.ReadLine());

            for (int i = 0; i < totalColors; i++)
            {
                var colorAndClothes = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                var color = colorAndClothes[0];
                var clothes = colorAndClothes[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (string current in clothes) 
                {
                    if (!wardrobe[color].ContainsKey(current))
                    {
                        wardrobe[color][current] = 0;
                    }

                    wardrobe[color][current]++;
                }
            }

            var searched = Console.ReadLine().Split();
            var searchedColor = searched[0];
            var searchedClothes = searched[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var current in color.Value)
                {
                    Console.Write($"* {current.Key} - {current.Value} ");

                    if (color.Key == searchedColor && current.Key == searchedClothes)
                    {
                        Console.Write("(found!)");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
