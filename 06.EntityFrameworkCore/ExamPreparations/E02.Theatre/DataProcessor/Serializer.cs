namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatre = context
                .Theatres
                .ToArray()
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                        .Where(ticket => ticket.RowNumber >= 1 && ticket.RowNumber <= 5)
                        .Sum(ticket => decimal.Parse(ticket.Price.ToString("F2"))),
                    Tickets = t.Tickets
                        .Where(ticket => ticket.RowNumber >= 1 && ticket.RowNumber <= 5)
                        .Select(ticket => new
                        {
                            Price = decimal.Parse(ticket.Price.ToString("F2")),
                            RowNumber = ticket.RowNumber
                        })
                        .OrderByDescending(ticket => ticket.Price)
                        .ToArray()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            string json = JsonConvert.SerializeObject(theatre, Formatting.Indented);

            return json;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context
                .Plays
                .ToArray()
                .Where(p => p.Rating <= rating)
                .Select(p => new ExportPlayWithActorsDto()
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0f ? "Premier" : p.Rating.ToString(CultureInfo.InvariantCulture),
                    Genre = Enum.GetName(typeof(Genre), p.Genre),
                    Actors = p.Casts
                        .Where(c => c.IsMainCharacter)
                        .Select(c => new ExportPlayActorsDto()
                        {
                            FullName = c.FullName,
                            MainCharacter = $"Plays main character in '{p.Title}'."
                        })
                        .OrderByDescending(c => c.FullName)
                        .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            var sb = new StringBuilder();

            using (StringWriter writer = new StringWriter(sb))
            {
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);

                XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportPlayWithActorsDto[]), xmlRoot);

                xmlSerializer.Serialize(writer, plays, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
