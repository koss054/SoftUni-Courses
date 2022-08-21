using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    public class Car
    {
        string model;
        Engine engine;
        Cargo cargo;
        Tires[] tires;

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

        public Cargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }   

        public Tires[] Tires
        {
            get { return tires; }
            set { tires = value; }
        }

        public Car (string model, Engine engine, Cargo cargo, Tires[] tires)           
        {
            this.model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tires = tires;
        }

        public bool isTireUnderOne()
        {
            foreach (var tire in tires)
            {
                if (tire.TirePressure < 1)
                {
                    return true;
                }
            }

            return false;
        }

        public bool isEnginePowerful()
        {
            if (engine.Power > 250)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string WhoAmI()
        {
            return $"{model}";
        }
    }
}
