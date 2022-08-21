using System;
using System.Linq;

namespace E02._2x2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var matrixRow = matrixSize[0];
            var matrixCol = matrixSize[1];
            var matrix = new char[matrixRow, matrixCol];
            var currentMatches = 0;
            
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                var currentInput = Console.ReadLine().Split();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = char.Parse(currentInput[c]);
                }
            }

            for (int r = 0; r < matrix.GetLength(0) - 1; r++)
            {
                for (int c = 0; c < matrix.GetLength(1) - 1; c++)
                {
                    if (matrix[r, c] == matrix[r, c + 1] 
                        && matrix[r, c] == matrix[r + 1, c]
                        && matrix[r, c] == matrix[r + 1, c + 1])
                    {
                        currentMatches++;
                    }
                }
            }

            Console.WriteLine(currentMatches);
        }
    }
}
