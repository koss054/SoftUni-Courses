using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Watchlist.Data.Constants.DataConstants.Movie;

namespace Watchlist.Data.Enntities
{
    public class Movie
    {
        public Movie()
        {
            this.UsersMovies = new List<UserMovie>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(DirectorMaxLength)]
        public string Director { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public decimal Rating { get; set; }

        public int? GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public Genre? Genre { get; set; }

        public List<UserMovie> UsersMovies { get; set; }
    }
}
