namespace HouseRenting.Services.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Data.DataConstants.House;

    public class House
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [StringLength(MaxTitleLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(MaxAddressLength)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(MaxDescriptionLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal PricePerMonth { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }

        [Required]
        public int AgentId { get; set; }

        [ForeignKey(nameof(AgentId))]
        public Agent? Agent { get; set; }

        public string? RenterId { get; set; }
    }
}

//· Id – a unique integer, Primary Key
//· Title – a string with min length 10 and max length 50 (required)
//· Address – a string with min length 30 and max length 150 (require
//Description – a string with min length 50 and max length 500 (required)
//· ImageUrl – a string(required)
//· PricePerMonth – a decimal with min value 0 and max value 2000 (required)
//· CategoryId – an integer(required)
//· Category – a Category object
//· AgentId – an integer (required)
//· Agent – an Agent object
//· RenterId – a string
