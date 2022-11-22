namespace HouseRenting.Services.Users
{
    using Data;

    public class UserService : IUserService
    {
        private readonly HouseRentingDbContext data;

        public UserService(HouseRentingDbContext _data)
        {
            data = _data;
        }

        public string UserFullName(string userId)
        {
            var user = this.data.Users.Find(userId);

            if (string.IsNullOrEmpty(user.FirstName) ||
                string.IsNullOrEmpty(user.LastName))
            {
                return null;
            }

            return user.FirstName + " " + user.LastName;
        }
    }
}
