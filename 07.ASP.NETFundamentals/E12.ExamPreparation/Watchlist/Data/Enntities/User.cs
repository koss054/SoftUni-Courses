using Microsoft.AspNetCore.Identity;

namespace Watchlist.Data.Enntities
{
    public class User : IdentityUser
    {
        public User()
        {
            this.UsersMovies = new List<UserMovie>();
        }

        public List<UserMovie> UsersMovies { get; set; }
    }
}
