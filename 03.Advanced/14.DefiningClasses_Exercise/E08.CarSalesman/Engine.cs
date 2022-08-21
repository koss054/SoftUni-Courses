using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Engine
    {
        string model;
        int power;
        int displacement;
        string efficiency;

        public string Model
        {
            get { return model; }
            set { model = value; }

        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public int Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }

        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }

        public Engine()
        {

        }
        public Engine(string model, int power)
        {
            this.model = model;
            this.power = power;

            displacement = -1;
            efficiency = "n/a";
        }

        public Engine(string model, int power, int displacement)
            : this (model, power)
        {
            this.displacement = displacement;
        }

        public Engine(string model, int power, string efficiency)
            : this (model, power)
        {
            this.efficiency = efficiency;
        }

        public Engine (string model, int power, int displacement, string efficiency)
            : this (model, power, displacement)
        {
            this.efficiency = efficiency;
        }
    }
}
