using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();

            list.Add("Bruhhhhhh");
            list.Add("Bruhhhh23hh");
            list.Add("Bruhhhh241hh");
            list.Add("Bruhhh412hhh");
            list.Add("Bru123hhhhhh");

            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());
        }
    }
}
