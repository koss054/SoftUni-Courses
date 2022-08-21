namespace SoftJail.DataProcessor
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

    using Data;
    using SoftJail.DataProcessor.ExportDto;
    using System.Globalization;
    using System.IO;
    using System.Xml.Serialization;
    using System.Text;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context
                .Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                        .Select(po => new
                        {
                            OfficerName = po.Officer.FullName,
                            Department = po.Officer.Department.Name
                        })
                        .OrderBy(po => po.OfficerName)
                        .ToArray(),
                    TotalOfficerSalary = decimal.Parse(p.PrisonerOfficers.Sum(po => po.Officer.Salary)
                        .ToString("F2"))
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            string json = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return json;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            string[] prisonerNamesArray = prisonersNames
                .Split(',').ToArray();

            ExportPrisonerWithMailsDto[] prisoners = context
                .Prisoners
                .ToArray()
                .Where(p => prisonerNamesArray.Contains(p.FullName))
                .Select(p => new ExportPrisonerWithMailsDto()
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture),
                    Mails = p.Mails
                        .Select(m => new ExportPrisonerMailsDto()
                        {
                            Description = String.Join("", m.Description.Reverse())
                        })
                        .ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            var sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlSerializerNamespaces namespaces =
                new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Prisoners");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportPrisonerWithMailsDto[]), xmlRoot);

            xmlSerializer.Serialize(writer, prisoners, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}