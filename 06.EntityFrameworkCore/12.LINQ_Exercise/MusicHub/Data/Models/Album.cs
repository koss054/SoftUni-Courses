namespace MusicHub.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common;

    public class Album
    {
        private decimal price;

        public Album()
        {
            this.Songs = new HashSet<Song>();

            this.Price = 0;
            foreach(var s in this.Songs)
            {
                this.Price += s.Price;
            }
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.AlbumNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public decimal Price
        {
            get
            {
                return this.price;
            }
            
            set
            {
                this.price = value;
            }
        }

        [ForeignKey(nameof(Producer))]
        public int? ProducerId { get; set; }

        public virtual Producer Producer { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
