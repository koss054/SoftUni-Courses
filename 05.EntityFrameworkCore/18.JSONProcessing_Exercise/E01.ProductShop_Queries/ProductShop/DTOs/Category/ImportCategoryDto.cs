namespace ProductShop.DTOs.Category
{
    using Newtonsoft.Json;

    public class ImportCategoryDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
