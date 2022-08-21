namespace P04.Recharge
{
    public class Hybrid : Worker, ISleeper, IRechargeable
    {
        private int internalPowerCapacity;
        private int currentPower;
        private int tirednessPercentage;

        public Hybrid(string id, int capacity, int power) 
            : base(id)
        {
            this.internalPowerCapacity = capacity;
            this.currentPower = power;
        }

        public void Recharge()
        {
            this.currentPower = this.internalPowerCapacity;
            System.Console.WriteLine("Recharging....");
        }

        public void Sleep()
        {
            this.tirednessPercentage = 0;
            System.Console.WriteLine("Sleeping...");
        }

        public override void Work(int hours)
        {


            if (hours > 0)
            {
                this.Recharge();
            }

            HybridWork(hours);
        }

        private void HybridWork(int hours)
        {
            base.Work(hours);
            this.tirednessPercentage += (hours * 4);

            if (this.tirednessPercentage >= 100)
            {
                System.Console.WriteLine("Worker too tired...");
                this.Sleep();
            }

            this.currentPower -= hours;

            System.Console.WriteLine($"{this.GetType().Name} has {this.currentPower} power left.");
        }
    }
}
