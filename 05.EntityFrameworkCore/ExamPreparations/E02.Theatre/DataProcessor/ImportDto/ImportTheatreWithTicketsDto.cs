using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Theatre.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportTheatreWithTicketsDto
    {
        [Required]
        [StringLength(30, MinimumLength = 4)]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [Required]
        [Range(typeof(sbyte), "1", "10")]
        [JsonProperty("NumberOfHalls")]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        [JsonProperty("Director")]
        public string Director { get; set; }

        [JsonProperty("Tickets")]
        public ImportTheaterTicketsDto[] Tickets { get; set; }
    }
}
