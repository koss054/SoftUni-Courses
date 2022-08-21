namespace P01._Worker_Before
{
    using Contracts;

    public class Human : IWorker, IEat, ISleep
    {
        public void Eat()
        {
            System.Console.WriteLine("Person eating.");
        }

        public void Sleep()
        {
            System.Console.WriteLine("Person sleeping.");
        }

        public void Work()
        {
            System.Console.WriteLine("Person se skatava.");
        }
    }
}
