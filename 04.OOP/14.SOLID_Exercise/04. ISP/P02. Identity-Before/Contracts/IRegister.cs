namespace P02._Identity_Before.Contracts
{

    public interface IRegister
    {
        bool RequireUniqueEmail { get; }

        int MinRequiredPasswordLength { get; }

        int MaxRequiredPasswordLength { get; }

        void Register(string username, string password);
    }
}
