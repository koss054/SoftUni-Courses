using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace Footballers.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportTeamWithFootballersDto
    {
        [JsonProperty("Name")]
        [Required]
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression(@"^[A-Za-z0-9\s\.'-]{3,40}$")]
        public string Name { get; set; }

        [JsonProperty("Nationality")]
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Nationality { get; set; }

        [JsonProperty("Trophies")]
        [Required]
        public int Trophies { get; set; }

        [JsonProperty("Footballers")]
        public int[] FootballersId { get; set; }
    }
}
