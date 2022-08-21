using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using SoftJail.Common;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class ImportOfficerWithPrisonersDto
    {
        [Required]
        [MinLength(GlobalConstants.OfficerNameMinLength)]
        [MaxLength(GlobalConstants.OfficerNameMaxLength)]
        [XmlElement("Name")]
        public string FullName { get; set; }

        [Required]
        [Range(typeof(decimal), GlobalConstants.MinDecimalValue,
                                GlobalConstants.MaxDecimalValue)]
        [XmlElement("Money")]
        public decimal Salary { get; set; }

        [Required]
        [XmlElement("Position")]
        public string Position { get; set; }

        [Required]
        [XmlElement("Weapon")]
        public string Weapon { get; set; }

        [Required]
        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }
        
        [XmlArray("Prisoners")]
        public ImportOfficerPrisonersDto[] Prisoners { get; set; }
    }
}
