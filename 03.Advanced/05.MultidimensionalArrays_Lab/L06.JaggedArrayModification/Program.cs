using System;
using System.Linq;

namespace L06.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixRows = int.Parse(Console.ReadLine());
            var matrix = new int[matrixRows][];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] col = Console.ReadLine().Split().Select(int.Parse).ToArray();

                matrix[row] = col;
            }

            while (true)
            {
                var userInput = Console.ReadLine();

                if (userInput == "END")
                {
                    break;
                }

                var tokens = userInput.Split();
                var command = tokens[0];
                var row = int.Parse(tokens[1]);
                var col = int.Parse(tokens[2]);
                var value = int.Parse(tokens[3]);

                if (row < 0 || row >= matrix.Length || col < 0 || col >= matrix[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
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

            foreach (int[] row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
