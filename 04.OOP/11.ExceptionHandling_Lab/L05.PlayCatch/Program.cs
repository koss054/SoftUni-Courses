using System;
using System.Linq;

namespace L05.PlayCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfExceptions = 0;
            int[] integers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            while (numOfExceptions < 3)
            {
                string[] tokens = Console.ReadLine().Split();

                try
                {
                    string command = tokens[0];
                    int index = int.Parse(tokens[1]);

                    switch (command)
                    {
                        case "Replace":
                            int element = int.Parse(tokens[2]);
                            integers[index] = element;
                            break;
                        case "Print":
                            int endIndex = int.Parse(tokens[2]);

                            if (!(endIndex < integers.Length))
                            {
                                throw new ArgumentOutOfRangeException();
                            }

                            int[] printableArray = new int[integers.Length - index];
                            Array.Copy(integers, index, printableArray, 0, endIndex);
                            Console.WriteLine(string.Join(", ", printableArray));
                            break;
                        case "Show":
                            Console.WriteLine(integers[index]);
                            break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    numOfExceptions++;
                    Console.WriteLine("The index does not exist!");
                }
                catch (ArgumentOutOfRangeException)
                {
                    numOfExceptions++;
                    Console.WriteLine("The index does not exist!");
                }
                catch (FormatException)
                {
                    numOfExceptions++;
                    Console.WriteLine("The variable is not in the correct format!");
                }
            }

            Console.WriteLine(string.Join(", ", integers));
        }
    }
}
