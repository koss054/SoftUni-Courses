namespace Watchlist.Models.Movies
{
    using System.ComponentModel.DataAnnotations;

    using Data.Entities;

    using static Data.Constants.DataConstants.Movie;

    public class AddMovieViewModel
    {
        [Required]
        [StringLength(MaxTitleLength, MinimumLength = MinTitleLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(MaxDirectorLength, MinimumLength = MinDirectorLength)]
        public string Director { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), MinRatingValue, MaxRatingValue, ConvertValueInInvariantCulture = false)]
        public decimal Rating { get; set; }

        [Required]
        public int GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();
    }
}
