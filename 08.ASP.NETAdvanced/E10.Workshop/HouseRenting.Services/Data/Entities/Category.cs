namespace HouseRenting.Services.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Category;

    public class Category
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<House> Houses { get; init; } = new List<House>();
    }
}
