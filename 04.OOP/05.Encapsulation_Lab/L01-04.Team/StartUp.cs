using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var people = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                var personInfo = Console.ReadLine().Split();
                var firstName = personInfo[0];
                var lastName = personInfo[1];
                var age = int.Parse(personInfo[2]);
                var salary = decimal.Parse(personInfo[3]);

                var person = new Person(firstName, lastName, age, salary);
                people.Add(person);
            }

            //people.OrderBy(x => x.FirstName)
            //    .ThenBy(x => x.Age)
            //    .ToList()
            //    .ForEach(x => Console.WriteLine(x.ToString()));

            //var percentage = decimal.Parse(Console.ReadLine());
            //people.ForEach(x => x.IncreaseSalary(percentage));
            //people.ForEach(x => Console.WriteLine(x.ToString()));

            Team team = new Team("SoftUni");

            foreach (Person person in people)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}
