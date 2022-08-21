namespace P04.Recharge
{
    public abstract class Worker : IWorker
    {
        private string id;
        private int workingHours;

        protected Worker(string id)
        {
            this.id = id;
        }

        public string Id 
        { 
            get { return this.id; }
        }

        public virtual void Work(int hours)
        {
            this.workingHours += hours;
            System.Console.WriteLine($"{this.GetType().Name} has worked for a total of {this.workingHours} hours!");
        }
    }
}