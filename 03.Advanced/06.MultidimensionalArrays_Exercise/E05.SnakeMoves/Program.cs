using System;
using System.Linq;

namespace E05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = dimensions[0];
            var cols = dimensions[1];

            var matrix = new char[rows, cols];
            var snakeString = Console.ReadLine();
            var counter = -1;

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (counter == snakeString.Length - 1)
                        {
                            counter = -1;
                        }

                        counter++;
                        matrix[row, col] = snakeString[counter];
                    }                   
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (counter == snakeString.Length - 1)
                        {
                            counter = -1;
                        }

                        counter++;
                        matrix[row, col] = snakeString[counter];
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {

                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }

                Console.WriteLine();
            }
        }
    }
}
