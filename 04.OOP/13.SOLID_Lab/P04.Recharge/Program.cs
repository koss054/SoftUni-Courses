namespace P04.Recharge
{
    using System;

    class Program
    {
        static void Main()
        {
            var employee = new Employee("222002");
            var robot = new Robot("11011101", 100, 51);
            var hybrid = new Hybrid("2110221", 100, 20);

            employee.Work(8);
            employee.Work(2);
            employee.Sleep();

            robot.Work(50);
            robot.Recharge();
            robot.Work(10);

            hybrid.Work(10);
            hybrid.Work(10);
            hybrid.Work(10);
        }
    }
}
