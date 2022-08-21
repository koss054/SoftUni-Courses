namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Projects");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectWithTasksDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            var projectDtos = (ImportProjectWithTasksDto[])xmlSerializer.Deserialize(reader);

            ICollection<Project> validProjects = new List<Project>();

            foreach (var pDto in projectDtos)
            {
                if (!IsValid(pDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isProjectOpenDateValid =
                    DateTime.TryParseExact(pDto.OpenDate,
                                           "dd/MM/yyyy",
                                           CultureInfo.InvariantCulture,
                                           DateTimeStyles.None,
                                           out DateTime projectOpenDate);

                if (!isProjectOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? projectDueDate = null;

                if (!String.IsNullOrWhiteSpace(pDto.DueDate))
                {
                    bool isProjectDueDateValid =
                    DateTime.TryParseExact(pDto.DueDate,
                                           "dd/MM/yyyy",
                                           CultureInfo.InvariantCulture,
                                           DateTimeStyles.None,
                                           out DateTime dueDate);

                    if (!isProjectDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    projectDueDate = dueDate;
                }

                var project = new Project()
                {
                    Name = pDto.Name,
                    OpenDate = projectOpenDate,
                    DueDate = projectDueDate,
                };

                foreach (var tDto in pDto.Tasks)
                {
                    if (!IsValid(tDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isTaskOpenDateValid =
                        DateTime.TryParseExact(tDto.OpenDate,
                                               "dd/MM/yyyy",
                                               CultureInfo.InvariantCulture,
                                               DateTimeStyles.None,
                                               out DateTime taskOpenDate);

                    if (!isTaskOpenDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isTaskDueDateValid =
                        DateTime.TryParseExact(tDto.DueDate,
                                               "dd/MM/yyyy",
                                               CultureInfo.InvariantCulture,
                                               DateTimeStyles.None,
                                               out DateTime taskDueDate);

                    if (!isTaskDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < projectOpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (projectDueDate.HasValue && taskDueDate > projectDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isTaskExecutionTypeValid =
                        Enum.TryParse(typeof(ExecutionType), tDto.ExecutionType, out object taskExecutionTypeObj);

                    if (!isTaskExecutionTypeValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isTaskLabelTypeValid
                        = Enum.TryParse(typeof(LabelType), tDto.LabelType, out object taskLabelTypeObj);

                    if (!isTaskLabelTypeValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var task = new Task()
                    {
                        Name = tDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskExecutionTypeObj,
                        LabelType = (LabelType)taskLabelTypeObj
                    };

                    project.Tasks.Add(task);
                }

                validProjects.Add(project);
                sb.AppendLine(String.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            context.Projects.AddRange(validProjects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();

            ImportEmployeeWithTasksDto[] employeeDtos = 
                JsonConvert.DeserializeObject<ImportEmployeeWithTasksDto[]>(jsonString);

            ICollection<Employee> validEmployees = new List<Employee>();

            foreach (var eDto in employeeDtos)
            {
                if (!IsValid(eDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee()
                {
                    Username = eDto.Username,
                    Email = eDto.Email,
                    Phone = eDto.Phone,
                };

                foreach (int taskId in eDto.Tasks.Distinct())
                {
                    Task t = context.Tasks.Find(taskId);

                    if (t == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var task = new EmployeeTask()
                    {
                        Task = t
                    };

                    employee.EmployeesTasks.Add(task);
                }

                validEmployees.Add(employee);
                sb.AppendLine(String.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(validEmployees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}