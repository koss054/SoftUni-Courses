namespace CarDealer.DTO.Car
{
    using Newtonsoft.Json;

    public class ExportCarDto
    {
        [JsonProperty(nameof(Make))]
        public string Make { get; set; }

        [JsonProperty(nameof(Model))]
        public string Model { get; set; }

        [JsonProperty(nameof(TravelledDistance))]
        public long TravelledDistance { get; set; }
    }
}
