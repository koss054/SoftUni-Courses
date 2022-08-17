using System;

namespace E07.ProjectsCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            string architectName = Console.ReadLine();
            int numOfProjects = int.Parse(Console.ReadLine());

            int neededHoursPerProject = 3;
            int neededTotalHours = numOfProjects * neededHoursPerProject;

            Console.WriteLine($"The architect {architectName} will need {neededTotalHours} hours to complete {numOfProjects} project/s.");
        }
    }
}
