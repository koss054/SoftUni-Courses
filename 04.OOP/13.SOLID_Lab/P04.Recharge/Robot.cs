namespace P04.Recharge
{
    public class Robot : Worker, IRechargeable
    {
        private int capacity;
        private int currentPower;

        public Robot(string id, int capacity, int currentPower) 
            : base(id)
        {
            this.capacity = capacity;
            this.currentPower = currentPower;
        }

        public int Capacity
        {
            get { return this.capacity; }
        }

        public int CurrentPower
        {
            get { return this.currentPower; }
        }

        public override void Work(int hours)
        {
            if (hours > this.currentPower)
            {
                hours = currentPower;
            }

            RobotWork(hours);
        }

        public void Recharge()
        {
            this.currentPower = this.capacity;
        }

        private void RobotWork(int hours)
        {
            base.Work(hours);
            this.currentPower -= hours;

            System.Console.WriteLine($"{this.GetType().Name} has {this.currentPower} power left");
        }
    }
}