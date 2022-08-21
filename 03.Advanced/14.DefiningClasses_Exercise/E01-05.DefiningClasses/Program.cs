using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var listOfPeople = new List<Person>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] userInput = Console.ReadLine().Split();
                string currentName = userInput[0];
                int currentAge = int.Parse(userInput[1]);

                Person currentPerson = new Person(currentName, currentAge);
                listOfPeople.Add(currentPerson);
            }

            var sortedList = listOfPeople.Where(p => p.Age > 30)
                .OrderBy(p => p.Name);

            foreach (var person in sortedList)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
