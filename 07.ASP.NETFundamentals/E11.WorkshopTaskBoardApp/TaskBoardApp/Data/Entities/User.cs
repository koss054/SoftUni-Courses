using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;

using static TaskBoardApp.Data.Constants.DataConstants.User;

namespace TaskBoardApp.Data.Entities
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(LastNameMaxLength)]
        public string LastName { get; set; }
    }
}
