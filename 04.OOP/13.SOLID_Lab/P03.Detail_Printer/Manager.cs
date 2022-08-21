namespace P03.Detail_Printer
{
    using System.Collections.Generic;

    public class Manager : Employee
    {
        public Manager(string name, List<string> documents) 
            : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; private set; }

        public override string ToString()
            => base.ToString() 
            + " - Current Documents: " 
            + string.Join(", ", this.Documents);
    }
}
