namespace P03.Detail_Printer
{
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            List<string> managerDocuments = new List<string>
            {
                "Shifts",
                "Manager Breaks",
                "Costs",
                "Team Statistics"
            };

            var employee = new Junior("Ivan", 22);
            var manager = new Manager("Georgi", managerDocuments);
            var receptionist = new Receptionist("Mihail", (ReceptionistShifts)1);

            var employees = new List<IEmployee>()
            {
                employee,
                manager,
                receptionist
            };

            var detailsPrinter = new DetailsPrinter(employees);
            detailsPrinter.PrintDetails();
        }
    }
}
