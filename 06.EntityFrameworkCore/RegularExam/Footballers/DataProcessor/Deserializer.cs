using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Newtonsoft.Json;

using Footballers.Data;
using Footballers.Data.Models;
using Footballers.Data.Models.Enums;
using Footballers.DataProcessor.ImportDto;

namespace Footballers.DataProcessor
{

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var sb = new StringBuilder();

            XmlRootAttribute xmlRoot 
                = new XmlRootAttribute("Coaches");
            XmlSerializer xmlSerializer = 
                new XmlSerializer(typeof(ImportCoachWithFootballersDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            ImportCoachWithFootballersDto[] coachDtos = (ImportCoachWithFootballersDto[])
                xmlSerializer.Deserialize(reader);

            ICollection<Coach> validCoaches = new List<Coach>();

            foreach (var cDto in coachDtos)
            {
                //Invalid name or null, or empty natioanlity
                if (!IsValid(cDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var coach = new Coach()
                {
                    Name = cDto.Name,
                    Nationality = cDto.Nationality
                };

                foreach (var fDto in cDto.Footballers)
                {
                    //Invalid name, start or end date are missing
                    if (!IsValid(fDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isContractStartDateValid =
                        DateTime.TryParseExact(fDto.ContractStartDate,
                                               "dd/MM/yyyy",
                                               CultureInfo.InvariantCulture,
                                               DateTimeStyles.None,
                                               out DateTime contractStartDate);

                    //Invalid start date
                    if (!isContractStartDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isContractEndDateValid =
                        DateTime.TryParseExact(fDto.ContractEndDate,
                                               "dd/MM/yyyy",
                                               CultureInfo.InvariantCulture,
                                               DateTimeStyles.None,
                                               out DateTime contractEndDate);

                    //Invalid end date
                    if (!isContractEndDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    //Start date is after end date
                    if (contractStartDate > contractEndDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isBestSkillTypeValid =
                        Enum.TryParse(typeof(BestSkillType),
                                      fDto.BestSkillType,
                                      out object bestSkillTypeObject);

                    //Invalid skill type - not required in the problem, may need to comment this validation
                    if (!isBestSkillTypeValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isPositionTypeValid =
                        Enum.TryParse(typeof(PositionType),
                                      fDto.PositionType,
                                      out object positionTypeObject);

                    //Invalid position type - not required in the problem, may need to comment this validation
                    if (!isPositionTypeValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var footballer = new Footballer()
                    {
                        Name = fDto.Name,
                        ContractStartDate = contractStartDate,
                        ContractEndDate = contractEndDate,
                        BestSkillType = (BestSkillType)bestSkillTypeObject,
                        PositionType = (PositionType)positionTypeObject
                    };

                    coach.Footballers.Add(footballer);
                }

                validCoaches.Add(coach);
                sb.AppendLine(String.Format(SuccessfullyImportedCoach, 
                                            coach.Name, 
                                            coach.Footballers.Count));
            }

            context.Coaches.AddRange(validCoaches);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var sb = new StringBuilder();

            ImportTeamWithFootballersDto[] teamDtos =
                JsonConvert.DeserializeObject<ImportTeamWithFootballersDto[]>(jsonString);

            ICollection<Team> validTeams = new List<Team>();

            foreach (var tDto in teamDtos)
            {
                //Invalid name, missing nationality
                if (!IsValid(tDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //0 or less trophies are invalid and such teams shouldn't be processed
                if (tDto.Trophies <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var team = new Team()
                {
                    Name = tDto.Name,
                    Nationality = tDto.Nationality,
                    Trophies = tDto.Trophies
                };

                foreach (var footballerId in tDto.FootballersId.Distinct())
                {
                    //Skipping footballer if they don't exist in the DB
                    if (!context.Footballers.Any(f => f.Id == footballerId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var tf = new TeamFootballer()
                    {
                        Team = team,
                        FootballerId = footballerId
                    };

                    team.TeamsFootballers.Add(tf);
                }

                validTeams.Add(team);
                sb.AppendLine(String.Format(SuccessfullyImportedTeam, 
                              team.Name, 
                              team.TeamsFootballers.Count));
            }

            context.Teams.AddRange(validTeams);
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
