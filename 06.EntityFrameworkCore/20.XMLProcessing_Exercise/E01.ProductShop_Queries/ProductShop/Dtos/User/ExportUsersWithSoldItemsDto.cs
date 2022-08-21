namespace ProductShop.Dtos.User
{
    using System.Xml.Serialization;

    using ProductShop.Dtos.Product;

    [XmlType("User")]
    public class ExportUsersWithSoldItemsDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public ExportSoldProductsDto[] SoldProducts { get; set; }
    }
}
