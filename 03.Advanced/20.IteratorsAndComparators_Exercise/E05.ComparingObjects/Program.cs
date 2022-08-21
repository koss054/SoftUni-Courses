using System;
using System.Collections.Generic;
using System.Linq;

namespace E05.ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] currentPerson = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = currentPerson[0];
                int age = int.Parse(currentPerson[1]);
                string town = currentPerson[2];

                var person = new Person(name, age, town);
                people.Add(person);

                input = Console.ReadLine();
            }

            int n = int.Parse(Console.ReadLine());

            Person personToCompare = people[n - 1];

            int equal = 0;
            int different = 0;

            foreach (var person in people)
            {
                if (person.CompareTo(personToCompare) == 0)
                {
                    equal++;
                }
                else
                {
                    different++;
                }
            }

            if (equal == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equal} {different} {people.Count}");
            }
        }
    }
}
