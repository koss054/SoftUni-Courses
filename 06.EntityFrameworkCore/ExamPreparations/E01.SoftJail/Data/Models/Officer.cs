using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SoftJail.Common;
using SoftJail.Data.Models.Enums;

namespace SoftJail.Data.Models
{
    public class Officer
    {
        public Officer()
        {
            this.OfficerPrisoners = new HashSet<OfficerPrisoner>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.OfficerNameMaxLength)]
        public string FullName { get; set; }

        public decimal Salary { get; set; }

        public Position Position { get; set; }

        public Weapon Weapon { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }

        [Required]
        public virtual Department Department { get; set; }

        public ICollection<OfficerPrisoner> OfficerPrisoners { get; set; }
    }
}
