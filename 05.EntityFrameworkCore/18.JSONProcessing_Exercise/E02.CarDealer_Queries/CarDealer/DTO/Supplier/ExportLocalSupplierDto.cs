namespace CarDealer.DTO.Supplier
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ExportLocalSupplierDto
    {
        [JsonProperty(nameof(Id))]
        public int Id { get; set; }

        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        [JsonProperty(nameof(PartsCount))]
        public int PartsCount { get; set; }
    }
}
