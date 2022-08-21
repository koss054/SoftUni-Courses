using System;
using System.Linq;

namespace E06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            var matrix = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine().Split().Select(double.Parse).ToArray();

                matrix[row] = currentRow;
            }

            int i = 0;
            int previousRowLength = 0;

            foreach (double[] row in matrix)
            {                
                if (i != 0)
                {
                    if (row.Length == previousRowLength)
                    {
                        for (int c = 0; c < row.Length; c++)
                        {
                            matrix[i - 1][c] *= 2;
                            matrix[i][c] *= 2;
                        }
                    }
                    else
                    {
                        for (int c = 0; c < previousRowLength; c++)
                        {
                            matrix[i - 1][c] /= 2;
                        }

                        for (int c = 0; c < row.Length; c++)
                        {
                            matrix[i][c] /= 2;
                        }
                    }
                }

                previousRowLength = row.Length;
                i++;
            }

            while (true)
            {
                var userInput = Console.ReadLine().Split();
                var command = userInput[0];

                if (command == "End")
                {
                    foreach (double[] r in matrix)
                    {
                        Console.WriteLine(string.Join(" ", r));
                    }

                    return;
                }

                var row = int.Parse(userInput[1]);
                var col = int.Parse(userInput[2]);
                var value = int.Parse(userInput[3]);

                if (row < rows && row >= 0)
                {
                    if (col < matrix[row].Length && col >= 0)
                    {
                        switch (command)
                        {
                            case "Add":
                                matrix[row][col] += value;
                                break;
                            case "Subtract":
                                matrix[row][col] -= value;
                                break;
                        }
                    }
                }

            }
        }
    }
}
