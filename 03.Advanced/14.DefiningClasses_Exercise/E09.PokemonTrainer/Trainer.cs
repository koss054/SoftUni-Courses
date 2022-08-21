using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        string name;
        int badges;
        List<Pokemon> pokemons;

        public Trainer(string name)
        {
            Name = name;
            Badges = 0;
            Pokemons = new List<Pokemon>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Badges
        {
            get { return badges; }
            set { badges = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }

        public override string ToString()
        {
            return $"{Name} {Badges} {Pokemons.Count}";
        }
    }
}
