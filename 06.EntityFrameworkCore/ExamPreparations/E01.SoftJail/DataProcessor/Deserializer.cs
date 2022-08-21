namespace SoftJail.DataProcessor
{

    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Globalization;
    using System.Xml.Serialization;
    using System.IO;
    using SoftJail.Data.Models.Enums;

    using Newtonsoft.Json;

    using Data;
    using SoftJail.DataProcessor.ImportDto;
    using SoftJail.Data.Models;


    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            ImportDepartmentWithCellsDto[] departmentDtos =
                JsonConvert.DeserializeObject<ImportDepartmentWithCellsDto[]>(jsonString);

            ICollection<Department> validDepartments =
                new List<Department>();

            foreach (var dDto in departmentDtos)
            {
                if (!IsValid(dDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (!dDto.Cells.Any())
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (dDto.Cells.Any(c => !IsValid(c)))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var department = new Department()
                {
                    Name = dDto.Name
                };

                foreach (var cDto in dDto.Cells)
                {
                    var cell = new Cell()
                    {
                        CellNumber = cDto.CellNumber,
                        HasWindow = cDto.HasWindow
                    };
                         
                    department.Cells.Add(cell);
                }

                validDepartments.Add(department);
                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            context.Departments.AddRange(validDepartments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            ImportPrisonerWithMailsDto[] prisonerDtos =
                JsonConvert.DeserializeObject<ImportPrisonerWithMailsDto[]>(jsonString);

            ICollection<Prisoner> validPrisoners =
                new List<Prisoner>();

            foreach (var pDto in prisonerDtos)
            {
                if (!IsValid(pDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (pDto.Mails.Any(m => !IsValid(m)))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isIncarcerationDateValid =
                    DateTime.TryParseExact(pDto.IncarcerationDate,
                                     "dd/MM/yyyy",
                                     CultureInfo.InvariantCulture,
                                     DateTimeStyles.None,
                                     out DateTime incarcerationDate);

                if (!isIncarcerationDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime? releaseDate = null;

                if (!String.IsNullOrEmpty(pDto.ReleaseDate))
                {
                    bool isReleaseDateValid =
                        DateTime.TryParseExact(pDto.ReleaseDate,
                                               "dd/MM/yyyy",
                                               CultureInfo.InvariantCulture,
                                               DateTimeStyles.None,
                                               out DateTime releaseDateValue);

                    if (!isReleaseDateValid)
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    releaseDate = releaseDateValue;
                }

                var prisoner = new Prisoner()
                {
                    FullName = pDto.FullName,
                    Nickname = pDto.Nickname,
                    Age = pDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = pDto.Bail,
                    CellId = pDto.CellId
                };

                foreach (var mDto in pDto.Mails)
                {
                    var mail = new Mail()
                    {
                        Description = mDto.Description,
                        Sender = mDto.Sender,
                        Address = mDto.Address
                    };

                    prisoner.Mails.Add(mail);
                }

                validPrisoners.Add(prisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Officers");
            XmlSerializer xmlSerializer = new XmlSerializer
                (typeof(ImportOfficerWithPrisonersDto[]), xmlRoot);

            ICollection<Officer> validOfficers =
                new List<Officer>();

            using (StringReader reader = new StringReader(xmlString))
            {
                ImportOfficerWithPrisonersDto[] officerDtos =
                    (ImportOfficerWithPrisonersDto[])
                    xmlSerializer.Deserialize(reader);

                foreach (var oDto in officerDtos)
                {
                    if (!IsValid(oDto))
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    bool isPositionValid =
                        Enum.TryParse(typeof(Position), oDto.Position, out object officerPosition);

                    if (!isPositionValid)
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    bool isWeaponValid =
                        Enum.TryParse(typeof(Weapon), oDto.Weapon, out object officerWeapon);

                    if (!isWeaponValid)
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    Officer officer = new Officer()
                    {
                        FullName = oDto.FullName,
                        Salary = oDto.Salary,
                        Position = (Position)officerPosition,
                        Weapon = (Weapon)officerWeapon,
                        DepartmentId = oDto.DepartmentId
                    };

                    foreach (ImportOfficerPrisonersDto pDto in oDto.Prisoners)
                    {
                        officer.OfficerPrisoners.Add(new OfficerPrisoner()
                        {
                            Officer = officer,
                            PrisonerId = pDto.Id
                        });
                    }

                    validOfficers.Add(officer);
                    sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
                }

                context.Officers.AddRange(validOfficers);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}