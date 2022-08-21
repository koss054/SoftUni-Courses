namespace CarDealer.DTO.Car
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ExportCarsFromMakeToyotaDto
    {
        [JsonProperty(nameof(Id))]
        public int Id { get; set; }

        [JsonProperty(nameof(Make))]
        public string Make { get; set; }

        [JsonProperty(nameof(Model))]
        public string Model { get; set; }

        [JsonProperty(nameof(TravelledDistance))]
        public long TravelledDistance { get; set; }
    }
}
