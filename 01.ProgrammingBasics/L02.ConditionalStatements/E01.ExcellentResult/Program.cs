using System;

namespace E01.ExcellentResult
{
    class Program
    {
        static void Main(string[] args)
        {
            double score = double.Parse(Console.ReadLine());
            const double excellentResult = 5.50;

            if (score >= excellentResult)
                Console.WriteLine("Excellent!");
        }
    }
}
