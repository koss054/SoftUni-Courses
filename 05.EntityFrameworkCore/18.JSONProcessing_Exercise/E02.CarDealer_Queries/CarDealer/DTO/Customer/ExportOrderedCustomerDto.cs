namespace CarDealer.DTO.Customer
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ExportOrderedCustomerDto
    {
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        [JsonProperty(nameof(BirthDate))]
        public string BirthDate { get; set; }

        [JsonProperty(nameof(IsYoungDriver))]
        public bool IsYoungDriver { get; set; }
    }
}
