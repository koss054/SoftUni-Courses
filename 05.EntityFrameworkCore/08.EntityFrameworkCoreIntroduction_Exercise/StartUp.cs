using System;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();
            // Console.WriteLine(GetEmployeesFullInformation(dbContext));                       - Exercise 3
            // Console.WriteLine(GetEmployeesWithSalaryOver50000(dbContext));                   - Exercise 4
            // Console.WriteLine(GetEmployeesFromResearchAndDevelopment(dbContext));            - Exercise 5
            // Console.WriteLine(AddNewAddressToEmployee(dbContext));                           - Exercise 6
            // Console.WriteLine(GetEmployeesInPeriod(dbContext));                              - Exercise 7
            // Console.WriteLine(GetAddressesByTown(dbContext));                                - Exercise 8
            // Console.WriteLine(GetEmployee147(dbContext));                                    - Exercise 9
            // Console.WriteLine(GetDepartmentsWithMoreThan5Employees(dbContext));              - Exercise 10
            // Console.WriteLine(GetLatestProjects(dbContext));                                 - Exercise 11
            // Console.WriteLine(IncreaseSalaries(dbContext));                                  - Exercise 12
            // Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(dbContext));             - Exercise 13
            // Console.WriteLine(DeleteProjectById(dbContext));                                 - Exercise 14
            Console.WriteLine(RemoveTown(dbContext));
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            Employee[] allEmployees = context
                .Employees
                .OrderBy(e => e.EmployeeId)
                .ToArray();

            foreach (var e in allEmployees)
            {
                output.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}");
            }

            return output.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            Employee[] allEmployeesWithSalaryOver50000 = context
                .Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToArray();

            foreach (var e in allEmployeesWithSalaryOver50000)
            {
                output.AppendLine($"{e.FirstName} - {e.Salary:F2}");
            }

            return output.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var allEmployeesFromResearchAndDevelopment = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new 
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToArray();

            foreach (var e in allEmployeesFromResearchAndDevelopment)
            {
                output.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}");
            }

            return output.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            Address newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee nakov = context
                .Employees
                .First(e => e.LastName == "Nakov");
            nakov.Address = newAddress;

            context.SaveChanges();

            var addressTexts = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => new
                {
                    e.Address.AddressText
                })
                .ToArray();

            foreach (var a in addressTexts)
            {
                output.AppendLine($"{a.AddressText}");
            }

            return output.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var employeeProjects = context
                .Employees
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 &&
                                                          ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    AllProjects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                            EndDate = ep.Project.EndDate.HasValue
                                ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt")
                                : "not finished"
                        })
                        .ToArray()
                })
                .ToArray();

            foreach (var e in employeeProjects)
            {
                output.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                foreach (var ep in e.AllProjects)
                {
                    output.AppendLine($"--{ep.ProjectName} - {ep.StartDate} - {ep.EndDate}");
                }
            }

            return output.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var allAddresses = context
                .Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeesCount = a.Employees.Count
                })
                .ToArray();

            foreach (var a in allAddresses)
            {
                output.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeesCount} employees");
            }

            return output.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var employee147 = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    AllProjects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name
                        })
                        .OrderBy(ep => ep.ProjectName)
                        .ToArray()
                })
                .ToArray();

            foreach (var e in employee147)
            {
                output.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");

                foreach (var ep in e.AllProjects)
                {
                    output.AppendLine($"{ep.ProjectName}");
                }
            }

            return output.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var allDepartments = context
                .Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    AllEmployees = d.Employees
                        .Select(e => new
                        {
                            EmployeeFirstName = e.FirstName,
                            EmployeeLastName = e.LastName,
                            EmployeeJobTitle = e.JobTitle
                        })
                        .OrderBy(e => e.EmployeeFirstName)
                        .ThenBy(e => e.EmployeeLastName)
                        .ToArray()
                })
                .ToArray();

            foreach (var d in allDepartments)
            {
                output.AppendLine($"{d.DepartmentName} – {d.ManagerFirstName} {d.ManagerLastName}");

                foreach (var e in d.AllEmployees)
                {
                    output.AppendLine($"{e.EmployeeFirstName} {e.EmployeeLastName} - {e.EmployeeJobTitle}");
                }
            }

            return output.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var allProjects = context
                .Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    ProjectName = p.Name,
                    p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt")
                })
                .OrderBy(p => p.ProjectName)
                .ToArray();

            foreach (var p in allProjects)
            {
                output.AppendLine($"{p.ProjectName}");
                output.AppendLine($"{p.Description}");
                output.AppendLine($"{p.StartDate}");
            }

            return output.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Engineering" ||
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    Salary = e.Salary + (e.Salary * 0.12m)
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var e in employees)
            {
                output.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
            }

            return output.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.FirstName.StartsWith("Sa") ||
                            e.FirstName.StartsWith("sa") ||
                            e.FirstName.StartsWith("sA") ||
                            e.FirstName.StartsWith("SA"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var e in employees)
            {
                output.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
            }

            return output.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var projectToDelete = context
                .Projects
                .Find(2);

            var refferedEmployees = context
                .EmployeesProjects
                .Where(ep => ep.ProjectId == projectToDelete.ProjectId)
                .ToArray();

            context.EmployeesProjects.RemoveRange(refferedEmployees);
            context.Projects.Remove(projectToDelete);
            context.SaveChanges();

            var projects = context
                .Projects
                .Take(10)
                .Select(p => new
                {
                    ProjectName = p.Name
                })
                .ToArray();

            foreach (var p in projects)
            {
                output.AppendLine($"{p.ProjectName}");
            }

            return output.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var townToDelete = context
                .Towns
                .First(t => t.Name == "Seattle");

            var addressessToDelete = context
                .Addresses
                .Where(a => a.Town.Name == townToDelete.Name);

            var refferedEmployees = context
                .Employees
                .Where(e => addressessToDelete.Any(a => a.AddressId == e.AddressId));

            foreach (var e in refferedEmployees)
            {
                e.AddressId = null;
            }

            int deletedAddressesCount = 0;

            foreach (var a in addressessToDelete)
            {
                context.Addresses.Remove(a);
                deletedAddressesCount++;
            }

            context.Towns.Remove(townToDelete);
            context.SaveChanges();

            return $"{deletedAddressesCount} addresses in Seattle were deleted";
        }
    }
}
