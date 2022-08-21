using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artillery.Data.Models
{
    public class CountryGun
    {
        [Required]
        public int CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public virtual Country Country { get; set; }

        [Required]
        public int GunId { get; set; }

        [ForeignKey(nameof(GunId))]
        public virtual Gun Gun { get; set; }
    }
}
