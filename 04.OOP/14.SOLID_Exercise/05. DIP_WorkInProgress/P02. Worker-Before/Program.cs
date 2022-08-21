using P02._Worker_Before.Contracts;
using System;

namespace P02._Worker_Before
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new Manager();
            manager.Work();

            IWorker assistantManager = new Manager();
            assistantManager.Work();
        }
    }
}
