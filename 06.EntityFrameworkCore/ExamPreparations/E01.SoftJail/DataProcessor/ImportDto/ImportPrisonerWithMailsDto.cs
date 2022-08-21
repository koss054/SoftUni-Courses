using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

using SoftJail.Common;

namespace SoftJail.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportPrisonerWithMailsDto
    {
        [Required]
        [MinLength(GlobalConstants.PrisonerNameMinLength)]
        [MaxLength(GlobalConstants.PrisonerNameMaxLength)]
        [JsonProperty(nameof(FullName))]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.PrisonerNicknameRegex)]
        [JsonProperty(nameof(Nickname))]
        public string Nickname { get; set; }

        [Required]
        [Range(GlobalConstants.PrisonerAgeMinValue,
               GlobalConstants.PrisonerAgeMaxValue)]
        [JsonProperty(nameof(Age))]
        public int Age { get; set; }

        [Required]
        [JsonProperty(nameof(IncarcerationDate))]
        public string IncarcerationDate { get; set; }

        [JsonProperty(nameof(ReleaseDate))]
        public string ReleaseDate { get; set; }

        [Range(typeof(decimal), GlobalConstants.MinDecimalValue,
                                GlobalConstants.MaxDecimalValue)]
        [JsonProperty(nameof(Bail))]
        public decimal? Bail { get; set; }

        [JsonProperty(nameof(CellId))]
        public int? CellId { get; set; }

        [JsonProperty(nameof(Mails))]
        public ImportPrisonerMailsDto[] Mails { get; set; }
    }
}
