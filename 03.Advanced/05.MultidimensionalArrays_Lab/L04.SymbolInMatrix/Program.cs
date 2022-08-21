using System;

namespace L04.SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            var matrix = new char[matrixSize, matrixSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentInput = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentInput[col];
                }
            }

            char searchedSymbol = char.Parse(Console.ReadLine());
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == searchedSymbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{searchedSymbol} does not occur in the matrix");
        }
    }
}
