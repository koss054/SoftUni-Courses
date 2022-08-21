namespace ProductShop.Dtos.User
{
    using System.Xml.Serialization;

    [XmlType("Users")]
    public class ExportUsersCountAndProductsInfoDto
    {
        [XmlElement("count")]
        public int UserCount { get; set; }

        [XmlArray("users")]
        public ExportUsersWithProductsDto[] Users { get; set; }
    }
}
