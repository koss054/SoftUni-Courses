namespace P01_StudentSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common;
    using Enums;

    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        [Column(TypeName = GlobalConstants.RecourceNameMaxLengthAndColumnType)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = GlobalConstants.VarcharDefault)]
        public string Url { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
