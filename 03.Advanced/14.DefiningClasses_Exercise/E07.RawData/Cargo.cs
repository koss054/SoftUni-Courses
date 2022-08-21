using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    public class Cargo
    {
        int cargoWeight;
        string cargoType;

        public int CargoWeight
        {
            get { return cargoWeight; }
            set { cargoWeight = value; }
        }

        public string CargoType
        {
            get { return cargoType; }
            set { cargoType = value; }
        }

        public Cargo(int cargoWeight, string cargoType)
        {
            this.cargoWeight = cargoWeight;
            this.cargoType = cargoType;
        }
    }
}
