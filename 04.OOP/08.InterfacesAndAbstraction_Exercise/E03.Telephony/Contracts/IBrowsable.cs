namespace Telephony.Contracts
{
    public interface IBrowsable : ICallable
    {
        string Browse(string url);
    }
}
