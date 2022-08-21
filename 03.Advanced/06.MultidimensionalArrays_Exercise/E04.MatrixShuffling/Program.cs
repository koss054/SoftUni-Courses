using System;
using System.Linq;

namespace E04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = dimensions[0];
            var cols = dimensions[1];
            var matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine().Split();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            while (true)
            {
                var currentCommandInput = Console.ReadLine().Split();

                if (currentCommandInput[0] == "END")
                {
                    return;
                }

                var isValid = true;
                var command = currentCommandInput[0];

                if (command != "swap" || currentCommandInput.Length != 5)
                {
                    isValid = false;
                }

                if (isValid)
                {
                    var row1 = int.Parse(currentCommandInput[1]);
                    var col1 = int.Parse(currentCommandInput[2]);
                    var row2 = int.Parse(currentCommandInput[3]);
                    var col2 = int.Parse(currentCommandInput[4]);

                    if (row1 < 0 || row1 >= rows || row2 < 0 || row2 >= rows
                        || col1 < 0 || col1 >= cols || col2 < 0 || col2 >= cols)
                    {
                        isValid = false;
                    }
                    else
                    {
                        var tempNum = matrix[row2, col2];
                        matrix[row2, col2] = matrix[row1, col1];
                        matrix[row1, col1] = tempNum;

                        for (int r = 0; r < rows; r++)
                        {
                            for (int c = 0; c < cols; c++)
                            {
                                Console.Write($"{matrix[r, c]} ");
                            }

                            Console.WriteLine();
                        }
                    }
                }

                if (!isValid)
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
