namespace P03.Detail_Printer
{
    public abstract class Employee : IEmployee
    {
        protected Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public override string ToString()
            => "Position: "
            + this.GetType().Name
            + " | Name: "
            + this.Name;
    }
}
