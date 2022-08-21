namespace ProductShop.Dtos.User
{
    using System.Xml.Serialization;

    using ProductShop.Dtos.Product;

    [XmlType("User")]
    public class ExportUsersWithProductsDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlElement("SoldProducts")]
        public ExportSoldProductsIncludingCountDto ProductsSold { get; set; }
    }
}
