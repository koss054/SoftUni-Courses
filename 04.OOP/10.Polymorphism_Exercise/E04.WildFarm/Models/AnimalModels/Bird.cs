namespace WildFarm
{
    public abstract class Bird : Animal, IBird
    {
        public Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; private set; }
    }
}
