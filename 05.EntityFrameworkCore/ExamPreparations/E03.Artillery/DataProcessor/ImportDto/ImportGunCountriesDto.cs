using Newtonsoft.Json;

namespace Artillery.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportGunCountriesDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
    }
}
