using System;

namespace Shapes
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius { get; protected set; }

        public override double CalculateArea()
            => Math.PI * this.Radius * this.Radius;

        public override double CalculatePerimeter()
            => 2 * Math.PI * this.Radius;

        public override string Draw()
            => base.Draw() + this.GetType().Name;
    }
}
