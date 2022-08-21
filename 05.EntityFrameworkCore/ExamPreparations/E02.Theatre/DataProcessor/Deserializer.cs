namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPlayDto[]), xmlRoot);

            ICollection<Play> validPlays = new List<Play>();

            using (StringReader reader = new StringReader(xmlString))
            {
                ImportPlayDto[] playDtos = (ImportPlayDto[])
                    xmlSerializer.Deserialize(reader);

                foreach (var pDto in playDtos)
                {
                    if (!IsValid(pDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    TimeSpan duration = TimeSpan.ParseExact(pDto.Duration, "c", CultureInfo.InvariantCulture);

                    if (duration.Hours < 1)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isGenreValid = Enum.TryParse(typeof(Genre), pDto.Genre, out object genreObj);

                    if (!isGenreValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var play = new Play()
                    {
                        Title = pDto.Title,
                        Duration = duration,
                        Rating = pDto.Rating,
                        Genre = (Genre)genreObj,
                        Description = pDto.Description,
                        Screenwriter = pDto.Screenwriter
                    };

                    validPlays.Add(play);
                    sb.AppendLine(String.Format(SuccessfulImportPlay, play.Title, play.Genre, play.Rating));
                }

                context.Plays.AddRange(validPlays);
                context.SaveChanges();

                return sb.ToString().TrimEnd();
            }
                
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Casts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCastDto[]), xmlRoot);

            ICollection<Cast> validCasts = new List<Cast>();

            using (StringReader writer = new StringReader(xmlString))
            {
                ImportCastDto[] castDtos = (ImportCastDto[])
                    xmlSerializer.Deserialize(writer);

                foreach (var cDto in castDtos)
                {
                    if (!IsValid(cDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var cast = new Cast()
                    {
                        FullName = cDto.FullName,
                        IsMainCharacter = cDto.IsMainCharacter,
                        PhoneNumber = cDto.PhoneNumber,
                        PlayId = cDto.PlayId
                    };

                    string mainOrLesser = String.Empty;

                    if (cast.IsMainCharacter)
                    {
                        mainOrLesser = "main";
                    }
                    else
                    {
                        mainOrLesser = "lesser";
                    }

                    validCasts.Add(cast);
                    sb.AppendLine(String.Format(SuccessfulImportActor, cast.FullName, mainOrLesser));
                }
            }

            context.Casts.AddRange(validCasts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var sb = new StringBuilder();

            ImportTheatreWithTicketsDto[] theatreDtos =
                JsonConvert.DeserializeObject<ImportTheatreWithTicketsDto[]>(jsonString);

            ICollection<Theatre> validTheatres = new List<Theatre>();

            foreach (var tDto in theatreDtos)
            {
                if (!IsValid(tDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var theatre = new Theatre()
                {
                    Name = tDto.Name,
                    NumberOfHalls = tDto.NumberOfHalls,
                    Director = tDto.Director
                };

                foreach (var ticketDto in tDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var ticket = new Ticket()
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId
                    };

                    theatre.Tickets.Add(ticket);
                }

                validTheatres.Add(theatre);
                sb.AppendLine(String.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }

            context.Theatres.AddRange(validTheatres);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
