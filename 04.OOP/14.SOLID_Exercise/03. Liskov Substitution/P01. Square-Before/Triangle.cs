namespace P01._Square_Before
{
    class Triangle : Shape
    {
        public Triangle(double triHeight, double triBase)
        {
            this.TriHeight = triHeight;
            this.TriBase = triBase;
        }

        public double TriHeight { get; private set; }

        public double TriBase { get; private set; }

        public override double Area => (TriHeight * TriBase) / 2;
    }
}
