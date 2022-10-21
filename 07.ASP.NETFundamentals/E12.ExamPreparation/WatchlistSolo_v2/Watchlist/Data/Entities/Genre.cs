namespace Watchlist.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    using static Data.Constants.DataConstants.Genre;

    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
