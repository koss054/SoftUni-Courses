using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Car
    {
        string model;
        Engine engine;
        int weight;
        string color;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public Car(string model, Engine engine)
        {
            this.model = model;
            this.engine = engine;

            weight = -1;
            color = "n/a";
        }

        public Car(string model, Engine engine, int weight)
            : this (model, engine)
        {
            this.weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this (model, engine)
        {
            this.color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            : this (model, engine, weight)
        {
            this.color = color;
        }

        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{model}:");
            sb.Append($"\n  {engine.Model}:");
            sb.Append($"\n    Power: {engine.Power}");

            if (engine.Displacement > 0)
            {
                sb.Append($"\n    Displacement: {engine.Displacement}");
            }
            else
            {
                sb.Append($"\n    Displacement: n/a");
            }

            sb.Append($"\n    Efficiency: {engine.Efficiency}");

            if (weight > 0)
            {
                sb.Append($"\n  Weight: {weight}");
            }
            else
            {
                sb.Append($"\n  Weight: n/a");
            }

            sb.Append($"\n  Color: {color}");

            return sb.ToString();
        }
    }
}
