namespace P02._Identity_Before
{
    using Contracts;

    public class AccountController : IChangePass
    {
        private readonly AccountManager manager;

        public AccountController(AccountManager manager)
        {
            this.manager = manager;
        }

        public void ChangePassword(string oldPass, string newPass)
        {
            this.manager.ChangePassword(oldPass, newPass);
        }
    }
}
