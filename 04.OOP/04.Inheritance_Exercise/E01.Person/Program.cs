using System;

namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            if (age <= 15)
            {
                Child person = new Child(name, age);
                Console.WriteLine(person);
            }
            else
            {
                Person person = new Person(name, age);
                Console.WriteLine(person);
            }
        }
    }
}
