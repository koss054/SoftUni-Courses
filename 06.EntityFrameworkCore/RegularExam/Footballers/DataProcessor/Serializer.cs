using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Globalization;
using System.Xml.Serialization;

using Newtonsoft.Json;

using Footballers.Data;
using Footballers.DataProcessor.ExportDto;

namespace Footballers.DataProcessor
{
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var coaches = context
                .Coaches
                .ToArray()
                .Where(c => c.Footballers.Count >= 1)
                .Select(c => new ExportCoachWithFootballersDto()
                {
                    FootballersCount = c.Footballers.Count,
                    CoachName = c.Name,
                    Footballers = c.Footballers
                        .Select(f => new ExportCoachFootballersDto()
                        {
                            Name = f.Name,
                            Position = f.PositionType.ToString()
                        })
                        .OrderBy(f => f.Name)
                        .ToArray()
                })
                .OrderByDescending(c => c.FootballersCount)
                .ThenBy(c => c.CoachName)
                .ToArray();

            var sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Coaches");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCoachWithFootballersDto[]), xmlRoot);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, coaches, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context
                .Teams
                .ToArray()
                .Where(t => t.TeamsFootballers.Any(f => f.Footballer.ContractStartDate > date))
                .Select(t => new
                {
                    Name = t.Name,
                    Footballers = t.TeamsFootballers
                        .ToArray()
                        .Where(tf => tf.Footballer.ContractStartDate > date)
                        .OrderByDescending(tf => tf.Footballer.ContractEndDate)
                        .ThenBy(tf => tf.Footballer.Name)
                        .Select(tf => new
                        {
                            FootballerName = tf.Footballer.Name,
                            ContractStartDate = tf.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                            ContractEndDate = tf.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                            BestSkillType = tf.Footballer.BestSkillType.ToString(),
                            PositionType = tf.Footballer.PositionType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(t => t.Footballers.Count())
                .ThenBy(t => t.Name)
                .Take(5)
                .ToArray();

            string json = JsonConvert.SerializeObject(teams, Formatting.Indented);

            return json.ToString().TrimEnd();
        }
    }
}
