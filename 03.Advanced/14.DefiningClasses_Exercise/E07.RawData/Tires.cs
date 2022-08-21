using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    public class Tires
    {
        double tirePressure;
        int tireAge;

        public double TirePressure
        {
            get { return tirePressure; }
            set { tirePressure = value; }
        }


        public int TireAge
        {
            get { return tireAge; }
            set { tireAge = value; }
        }

        public Tires(double tirePressure, int tireAge)
        {
            this.tirePressure = tirePressure;
            this.tireAge = tireAge;
        }
    }
}
