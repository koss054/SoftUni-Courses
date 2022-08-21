using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var stack = new StackOfStrings();
            Console.WriteLine(stack.IsEmpty());

            var elements = new string[] { "hello", "broo", "wadup" };
            stack.AddRange(elements);
            Console.WriteLine(stack.IsEmpty());
        }
    }
}
