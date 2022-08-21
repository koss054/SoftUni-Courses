namespace ProductShop.Dtos.Product
{
    using System.Xml.Serialization;

    [XmlType("Product")]
    public class ExportSoldProductsDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
