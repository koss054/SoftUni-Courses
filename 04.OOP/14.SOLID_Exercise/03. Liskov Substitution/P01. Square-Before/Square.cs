namespace P01._Square_Before
{
    public class Square : Shape
    {
        public Square(double side)
        {
            this.Side = side;
        }

        public double Side { get; private set; }

        public override double Area => Side * Side;
    }
}
