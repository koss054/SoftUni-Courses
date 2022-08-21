namespace P04.Recharge
{
    interface IWorker
    {
        public string Id { get; }

        public void Work(int hours);
    }
}
