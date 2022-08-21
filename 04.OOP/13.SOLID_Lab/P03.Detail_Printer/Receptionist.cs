namespace P03.Detail_Printer
{
    using System;

    public class Receptionist : Employee
    {
        public Receptionist(string name, Enum shift) 
            : base(name)
        {
            this.Shift = shift;
        }

        public Enum Shift { get; private set; }

        public override string ToString()
            => base.ToString()
            + "- Current Shift: "
            + this.Shift;
    }
}
