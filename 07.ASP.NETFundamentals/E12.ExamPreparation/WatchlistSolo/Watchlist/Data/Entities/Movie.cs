namespace Watchlist.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Constants.DataConstants.Movie;

    public class Movie
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(MaxTitleLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(MaxDirectorLength)]
        public string Director { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Rating { get; set; }

        public int? GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; } = null!;

        public ICollection<UserMovie> UsersMovies { get; set; } = new List<UserMovie>();
    }
}
