using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

using SoftJail.Common;

namespace SoftJail.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportPrisonerMailsDto
    {
        [Required]
        [JsonProperty(nameof(Description))]
        public string Description { get; set; }

        [Required]
        [JsonProperty(nameof(Sender))]
        public string Sender { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.MailAddressRegex)]
        [JsonProperty(nameof(Address))]
        public string Address { get; set; }
    }
}
