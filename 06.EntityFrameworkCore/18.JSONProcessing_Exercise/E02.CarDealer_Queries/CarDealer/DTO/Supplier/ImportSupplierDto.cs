﻿namespace CarDealer.DTO.Supplier
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ImportSupplierDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("isImporter")]
        public bool IsImporter { get; set; }
    }
}
