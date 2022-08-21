using System;
using System.Collections.Generic;
using System.Text;

namespace E01.ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double SurfaceArea()
        {
            double surfaceArea = (2 * (length * width)) + (2 * (length * height)) + (2 * (height * width));

            return surfaceArea;
        }

        public double LateralSurfaceArea()
        {
            double lateralSurfaceArea = (2 * (length * height)) + (2 * (width * height));

            return lateralSurfaceArea;
        }

        public double Volume()
        {
            double volume = length * width * height;

            return volume;
        }

        private double Length
        {
            get { return this.length; }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            } 
        }

        private double Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        private double Height
        {
            get { return this.height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }
    }
}
