namespace MusicHub.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class Writer
    {
        public Writer()
        {
            this.Songs = new HashSet<Song>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.WriterNameMaxLength)]
        public string Name { get; set; }

        public string Pseudonym { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
