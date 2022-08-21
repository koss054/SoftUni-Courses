using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Artillery.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportGunWithCountriesDto
    {
        [JsonProperty("ManufacturerId")]
        [Required]
        public int ManufacturerId { get; set; }

        [JsonProperty("GunWeight")]
        [Required]
        [Range(100, 1_350_000)]
        public int GunWeight { get; set; }

        [JsonProperty("BarrelLength")]
        [Required]
        [Range(2.00, 35.00, ConvertValueInInvariantCulture = true, ParseLimitsInInvariantCulture = true)]
        public double BarrelLength { get; set; }

        [JsonProperty("NumberBuild")]
        public int? NumberBuild { get; set; }

        [JsonProperty("Range")]
        [Required]
        [Range(1, 100_000)]
        public int Range { get; set; }

        [JsonProperty("GunType")]
        [Required]
        public string GunType { get; set; }

        [JsonProperty("ShellId")]
        [Required]
        public int ShellId { get; set; }

        [JsonProperty("Countries")]
        public ImportGunCountriesDto[] Countries { get; set; }
    }
}
