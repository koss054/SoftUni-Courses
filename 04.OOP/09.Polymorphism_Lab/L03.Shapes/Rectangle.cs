namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height { get; protected set; }

        public double Width { get; protected set; }

        public override double CalculateArea()
            => Height * Width;

        public override double CalculatePerimeter()
            => 2 * (Height + Width);

        public override string Draw()
            => base.Draw() + this.GetType().Name;
    }
}
