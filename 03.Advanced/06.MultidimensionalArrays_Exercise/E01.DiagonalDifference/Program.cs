using System;
using System.Linq;

namespace E01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            var matrix = new int[matrixSize, matrixSize];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                var currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = currentRow[c];
                }
            }

            var primaryDiagonalSum = 0;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (r == c)
                    {
                        primaryDiagonalSum += matrix[r, c];
                    }
                }
            }

            var secondaryDiagonalSum = 0;
            var secondaryRow = matrix.GetLength(0) - 1;
            var secondaryCol = 0;

            for (int i = 0; i < matrixSize; i++)
            {
                secondaryDiagonalSum += matrix[secondaryRow, secondaryCol];
                secondaryRow--;
                secondaryCol++;
            }

            var difference = primaryDiagonalSum - secondaryDiagonalSum;
            difference = Math.Abs(difference);

            Console.WriteLine(difference);
        }
    }
}
