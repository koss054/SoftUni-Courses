namespace ProductShop.DTOs.CategoryProduct
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ExportCategoryByProductCountDto
    {
        [JsonProperty("category")]
        public string Name { get; set; }

        [JsonProperty("productsCount")]
        public int ProductCount { get; set; }

        [JsonProperty("averagePrice")]
        public decimal AveragePrice { get; set; }

        [JsonProperty("totalRevenue")]
        public decimal TotalRevenue { get; set; }
    }
}
