namespace P03.Detail_Printer
{
    public class Junior : Employee
    {
        public Junior(string name, int daysWorked) 
            : base(name)
        {
            this.DaysWorked = daysWorked;
        }

        public int DaysWorked { get; private set; }

        public override string ToString()
            => base.ToString()
            + " - Days Worked in Company: "
            + this.DaysWorked;
    }
}
