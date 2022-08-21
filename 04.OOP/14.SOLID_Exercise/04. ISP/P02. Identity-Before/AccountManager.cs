using P02._Identity_Before.Contracts;

namespace P02._Identity_Before
{
    public class AccountManager : IRegister, IChangePass
    {
        public string Email { get; private set; }

        public string Password { get; private set; }

        public bool RequireUniqueEmail => true;

        public int MinRequiredPasswordLength => 8;

        public int MaxRequiredPasswordLength => 30;

        public void Register(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
        public void ChangePassword(string oldPass, string newPass)
        {
            if (oldPass == this.Password)
            {
                this.Password = newPass;
            }
        }

    }
}
