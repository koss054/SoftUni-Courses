using System;
using System.Linq;

namespace L01.SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int matrixRows = matrixSize[0];
            int matrixCols = matrixSize[1];
            int finalSum = 0;

            int[,] matrix = new int[matrixRows, matrixCols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    finalSum += matrix[row, col];
                }
            }

            Console.WriteLine(matrixRows);
            Console.WriteLine(matrixCols);
            Console.WriteLine(finalSum);
        }
    }
}
