using System;

namespace fundamentalsLesson6
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            double availableMoney = double.Parse(Console.ReadLine());
            int studentCount = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double lightsabersNeeded = studentCount + (studentCount * 0.1);
            lightsabersNeeded = Math.Ceiling(lightsabersNeeded);
            int freeBelts = 0;

            if (studentCount >= 6)
            {
                freeBelts = studentCount / 6;
            }

            double totalLightsaberPrice = lightsabersNeeded * lightsaberPrice;
            double totalRobesPrice = studentCount * robePrice;
            double totalBeltsPrice = (studentCount - freeBelts) * beltPrice;

            double totalCost = totalLightsaberPrice + totalRobesPrice + totalBeltsPrice;

            if (totalCost <=  availableMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {totalCost:F2}lv.");
            }
            else
            {
                double neededMoney = totalCost - availableMoney;
                Console.WriteLine($"John will need {neededMoney:F2}lv more.");
            }
        }
    }
}