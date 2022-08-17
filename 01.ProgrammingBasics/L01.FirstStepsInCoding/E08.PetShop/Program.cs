using System;

namespace E08.PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfDogs = int.Parse(Console.ReadLine());
            int numOfOtherAnimals = int.Parse(Console.ReadLine());

            double dogFoodCost = numOfDogs * 2.5;
            int otherAnimalFoodCost = numOfOtherAnimals * 4;
            double totalCost = dogFoodCost + otherAnimalFoodCost;

            Console.WriteLine($"{totalCost} lv.");
        }
    }
}
