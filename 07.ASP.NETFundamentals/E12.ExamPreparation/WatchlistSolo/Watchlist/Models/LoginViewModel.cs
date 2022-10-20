namespace Watchlist.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using static Data.Constants.DataConstants.User;

    public class LoginViewModel
    {
        [Required]
        [DisplayName(UsernameDisplayName)]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
