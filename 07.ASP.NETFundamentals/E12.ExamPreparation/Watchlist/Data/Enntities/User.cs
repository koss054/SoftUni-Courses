using Microsoft.AspNetCore.Identity;

namespace Watchlist.Data.Enntities
{
    public class User : IdentityUser
    {
        public List<UserMovie> UsersMovies { get; set; } = new List<UserMovie>();
    }
}
