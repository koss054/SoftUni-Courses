using System;
using System.Collections.Generic;

namespace L02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, List<double>>();
            int totalStudents = int.Parse(Console.ReadLine());

            for (int i = 0; i < totalStudents; i++)
            {
                var nameAndGrade = Console.ReadLine().Split();
                var name = nameAndGrade[0];
                var grade = double.Parse(nameAndGrade[1]);

                if (dictionary.ContainsKey(name))
                {
                    dictionary[name].Add(grade);
                }
                else
                {
                    dictionary[name] = new List<double>();
                    dictionary[name].Add(grade);
                }
            }

            foreach (var student in dictionary)
            {
                decimal averageGrade = 0;
                var totalGrades = 0;

                Console.Write($"{student.Key} -> ");

                foreach (var grades in student.Value)
                {
                    Console.Write($"{grades:F2} ");

                    averageGrade += (decimal)grades;
                    totalGrades++;
                }

                averageGrade /= (decimal)totalGrades;

                Console.WriteLine($"(avg: {averageGrade:F2})");
            }
        }
    }
}
