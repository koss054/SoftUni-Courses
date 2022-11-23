namespace HouseRenting.Services.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.AspNetCore.Identity;

    using static Data.DataConstants.Agent;

    public class Agent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(MaxPhoneLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
    }
}
