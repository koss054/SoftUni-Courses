namespace ProductShop.Dtos.Product
{
    using System.Xml.Serialization;

    [XmlType("SoldProducts")]
    public class ExportSoldProductsIncludingCountDto
    {
        [XmlElement("count")]
        public int ProductCount { get; set; }

        [XmlArray("products")]
        public ExportSoldProductsDto[] SoldProducts { get; set; }
    }
}
