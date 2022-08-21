namespace P02._DrawingShape_Before
{
    using Contracts;

    class Rectangle : IShape
    {
        public void Draw()
        {
            System.Console.WriteLine("Drawing rectangle.");
        }
    }
}
