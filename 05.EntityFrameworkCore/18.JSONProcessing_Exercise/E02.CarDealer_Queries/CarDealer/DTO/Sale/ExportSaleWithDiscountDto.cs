namespace CarDealer.DTO.Sale
{
    using CarDealer.DTO.Car;
    
    using Newtonsoft.Json;

    [JsonObject]
    public class ExportSaleWithDiscountDto
    {
        [JsonProperty("car")]
        public ExportCarDto Car { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; set; }

        [JsonProperty(nameof(Discount))]
        public string Discount { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("priceWithDiscount")]
        public string PriceWithDiscount
            => (decimal.Parse(this.Price) - (decimal.Parse(this.Price) * (decimal.Parse(this.Discount) / 100))).ToString("F2");
    }
}
