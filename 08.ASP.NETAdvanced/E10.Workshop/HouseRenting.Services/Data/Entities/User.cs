namespace HouseRenting.Services.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Identity;

    using static Data.DataConstants.User;

    public class User : IdentityUser
    {
        [Required]
        [StringLength(MaxFirstNameLength)]
        public string FirstName { get; init; }

        [Required]
        [StringLength(MaxLastNameLength)]
        public string LastName { get; init; }
    }
}
