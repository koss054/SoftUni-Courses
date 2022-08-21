using System;
using System.Linq;

namespace L02.SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var matrix = new int[matrixSize[0], matrixSize[1]];
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
                
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentInput[col];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                var sum = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sum += matrix[row, col];
                }

                Console.WriteLine(sum);
            }
        }
    }
}
