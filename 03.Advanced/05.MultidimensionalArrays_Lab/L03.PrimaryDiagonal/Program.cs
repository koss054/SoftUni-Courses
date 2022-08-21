using System;
using System.Linq;

namespace L03.PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int squareSize = int.Parse(Console.ReadLine());
            var matrix = new int[squareSize, squareSize];
            int finalSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        finalSum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(finalSum);
        }
    }
}
