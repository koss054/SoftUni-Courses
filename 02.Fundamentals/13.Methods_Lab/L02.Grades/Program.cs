using System;

namespace _02.Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            grades(double.Parse(Console.ReadLine()));
        }

        static void grades(double enteredGrade)
        {
            string finalGrade = string.Empty;

            if (enteredGrade >= 2.00 && enteredGrade <= 2.99)
            {
                finalGrade = "Fail";
            }
            else if (enteredGrade >= 3.00 && enteredGrade <= 3.49)
            {
                finalGrade = "Poor";
            }
            else if (enteredGrade >= 3.50 && enteredGrade <= 4.49)
            {
                finalGrade = "Good";
            }
            else if (enteredGrade >= 4.50 && enteredGrade <= 5.49)
            {
                finalGrade = "Very good";
            }
            else if (enteredGrade >= 5.50 && enteredGrade <= 6.00)
            {
                finalGrade = "Excellent";
            }

            Console.WriteLine(finalGrade);
        }
    }
}
