using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
    public class ImportCastDto
    {
        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string FullName { get; set; }

        [Required]
        public bool IsMainCharacter { get; set; }

        [Required]
        [StringLength(15)]
        [RegularExpression(@"^\+44\-[0-9][0-9]\-[0-9][0-9][0-9]\-[0-9][0-9][0-9][0-9]$")]
        public string PhoneNumber { get; set; }

        [Required]
        public int PlayId { get; set; }
    }
}
