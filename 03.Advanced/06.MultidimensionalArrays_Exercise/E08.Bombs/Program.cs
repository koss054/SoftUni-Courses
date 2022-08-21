using System;
using System.Linq;

namespace E08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = int.Parse(Console.ReadLine());
            var matrix = new int[dimensions, dimensions];
            
            for (int row = 0; row < dimensions; row++)
            {
                var currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < dimensions; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            var bombs = Console.ReadLine().Split();

            for (int i = 0; i < bombs.Length; i++)
            {
                var currentCoords = bombs[i].Split(",").Select(int.Parse).ToArray();
                var row = currentCoords[0];
                var col = currentCoords[1];

                if (matrix[row, col] > 0)
                {
                    int bombPower = matrix[row, col];
                    matrix[row, col] = 0;

                    if (col - 1 >= 0 && matrix[row, col - 1] > 0)                   //If there is a number to the left of the bomb.
                    {
                        matrix[row, col - 1] -= bombPower;
                    }

                    if (col + 1 < dimensions && matrix[row, col + 1] > 0)           //If there is a number to the right of the bomb.
                    {
                        matrix[row, col + 1] -= bombPower;
                    }

                    if (row - 1 >= 0)                                               //If there is a number above the bomb.
                    {
                        if (matrix[row - 1, col] > 0)
                        {
                            matrix[row - 1, col] -= bombPower;
                        }

                        if (col - 1 >= 0 && matrix[row - 1, col - 1] > 0)           //If there is a number to the left, above the bomb.
                        {
                            matrix[row - 1, col - 1] -= bombPower;
                        }

                        if (col + 1 < dimensions && matrix[row - 1, col + 1] > 0)   //If there is a number to the right, above the bomb.
                        {
                            matrix[row - 1, col + 1] -= bombPower;
                        }
                    }

                    if (row + 1 < dimensions)                                       //If there is a number below the bomb.
                    {
                        if (matrix[row + 1, col] > 0)
                        {
                            matrix[row + 1, col] -= bombPower;
                        }

                        if (col - 1 >= 0 && matrix[row + 1, col - 1] > 0)           //If there is a number to the left, below the bomb.
                        {
                            matrix[row + 1, col - 1] -= bombPower;
                        }

                        if (col + 1 < dimensions && matrix[row + 1, col + 1] > 0)   //If there is a number to the right, below the bomb.
                        {
                            matrix[row + 1, col + 1] -= bombPower;
                        }
                    }
                }
            }

            var aliveCells = 0;
            var sumOfAliveCells = 0;

            for (int row = 0; row < dimensions; row++)
            {
                for (int col = 0; col < dimensions; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sumOfAliveCells += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumOfAliveCells}");

            for (int row = 0; row < dimensions; row++)
            {
                
                for (int col = 0; col < dimensions; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
