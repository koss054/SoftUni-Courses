namespace Demo
{
    using System;
    using Tree;

    class Program
    {
        static void Main(string[] args)
        {
            var treeFactory = new IntegerTreeFactory();
            var input = new string[] { "7 19", "7 21", "7 14", "19 1", "19 12", "19 31", "14 23", "14 6" };
            
            var tree = treeFactory.CreateTreeFromStrings(input);
            Console.WriteLine(tree.AsString());

            var leafKeys = tree.GetLeafKeys();
            var internalKeys = tree.GetInternalKeys();

            Console.WriteLine(string.Join(" ", leafKeys));
            Console.WriteLine(string.Join(" ", internalKeys));
        }
    }
}
