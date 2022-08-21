using System;
using System.Linq;

namespace L05.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var matrix = new int[matrixSize[0], matrixSize[1]];

            int topLeftNumber = 0;
            int topRightNumber = 0;
            int bottomLeftNumber = 0;
            int bottomRightNumber = 0;
            int totalSum = 0;
            int biggestSquareSum = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    var newSquareSum = matrix[row, col] + matrix[row + 1, col]
                        + matrix[row, col + 1] + matrix[row + 1, col + 1];

                    if (newSquareSum > biggestSquareSum)
                    {
                        topLeftNumber = matrix[row, col];
                        topRightNumber = matrix[row, col + 1];
                        bottomLeftNumber = matrix[row + 1, col];
                        bottomRightNumber = matrix[row + 1, col + 1];
                        totalSum = topLeftNumber + topRightNumber + bottomLeftNumber + bottomRightNumber;
                        biggestSquareSum = newSquareSum;
                    }
                }
            }

            Console.WriteLine($"{topLeftNumber} {topRightNumber}");
            Console.WriteLine($"{bottomLeftNumber} {bottomRightNumber}");
            Console.WriteLine(totalSum);
        }
    }
}
