namespace ProductShop.Dtos.CategoryProduct
{
    using System.Xml.Serialization;

    [XmlType("CategoryProduct")]
    public class ImportCategoryProductDto
    {
        [XmlElement(nameof(CategoryId))]
        public int CategoryId { get; set; }

        [XmlElement(nameof(ProductId))]
        public int ProductId { get; set; }
    }
}
