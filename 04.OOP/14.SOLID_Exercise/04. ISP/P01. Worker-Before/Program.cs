namespace P01._Worker_Before
{
    using System.Collections.Generic;

    using P01._Worker_Before.Contracts;

    class Program
    {
        static void Main(string[] args)
        {
            var human = new Human();
            var robot = new Robot();

            List<IWorker> workers = new List<IWorker>();
            workers.Add(human);
            workers.Add(robot);

            foreach(var worker in workers)
            {
                worker.Work();
            }
        }
    }
}
