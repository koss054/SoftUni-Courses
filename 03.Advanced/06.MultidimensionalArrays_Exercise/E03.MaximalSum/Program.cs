using System;
using System.Linq;

namespace E03.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = matrixSize[0];
            var cols = matrixSize[1];
            var matrix = new int[rows][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            int maxSum = 0;
            int rowStartIndex = 0;
            int colStartIndex = 0;

            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int col = 0; col < matrix[row].Length - 2; col++)
                {
                    int sum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2]
                              + matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2]
                              + matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        rowStartIndex = row;
                        colStartIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = rowStartIndex; row <= rowStartIndex + 2; row++)
            {
                for (int col = colStartIndex; col <= colStartIndex + 2; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
