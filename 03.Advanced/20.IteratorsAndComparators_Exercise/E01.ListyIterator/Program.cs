using System;
using System.Linq;
using System.Collections.Generic;

namespace E01.ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                .Split()
                .Skip(1)
                .ToList();

            var listyIterator = new ListyIterator<string>(elements);

            string command = Console.ReadLine();

            try
            {
                while (command != "END")
                {
                    if (command == "HasNext")
                    {
                        Console.WriteLine(listyIterator.HasNext());
                    }
                    else if (command == "Move")
                    {
                        Console.WriteLine(listyIterator.Move());
                    }
                    else if (command == "Print")
                    {
                        listyIterator.Print();
                    }
                    else if (command == "PrintAll")
                    {
                        foreach (var element in listyIterator)
                        {
                            Console.Write($"{element} ");
                        }

                        Console.WriteLine();
                    }
                    command = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
