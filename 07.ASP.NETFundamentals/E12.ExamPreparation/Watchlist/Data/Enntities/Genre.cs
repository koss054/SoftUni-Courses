using System.ComponentModel.DataAnnotations;

using static Watchlist.Data.Constants.DataConstants.Genre;

namespace Watchlist.Data.Enntities
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
