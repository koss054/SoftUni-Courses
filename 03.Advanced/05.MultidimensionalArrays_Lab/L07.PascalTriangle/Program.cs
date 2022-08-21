using System;

namespace L07.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            long[][] triangle = new long[height][];
            int currentWidth = 1;

            for (long row = 0; row < height; row++)
            {
                triangle[row] = new long[currentWidth];
                long[] currentRow = triangle[row];
                currentRow[0] = 1;
                currentRow[currentRow.Length - 1] = 1;
                currentWidth++;

                if (currentRow.Length > 2)
                {
                    for (int i = 1; i < currentRow.Length - 1; i++)
                    {
                        long[] previousRow = triangle[row - 1];
                        long previousRowSum = previousRow[i] + previousRow[i - 1];
                        currentRow[i] = previousRowSum;
                    }
                }
            }

            foreach (long[] row in triangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
