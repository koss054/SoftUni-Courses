namespace P03.Detail_Printer
{
    using System;
    using System.Collections.Generic;

    public class DetailsPrinter
    {
        private IList<IEmployee> employees;

        public DetailsPrinter(IList<IEmployee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
