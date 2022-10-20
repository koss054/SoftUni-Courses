namespace Watchlist.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using static Data.Constants.DataConstants.User;

    public class RegisterViewModel
    {
        [Required]
        [DisplayName(UsernameDisplayName)]
        [StringLength(MaxUserNameLength, MinimumLength = MinUserNameLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(MaxEmailLength, MinimumLength = MinEmailLength)]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [StringLength(MaxPasswordLength, MinimumLength = MinPasswordLength)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
