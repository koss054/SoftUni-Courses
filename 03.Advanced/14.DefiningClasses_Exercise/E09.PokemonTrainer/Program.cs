﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace _09.PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var trainers = new Dictionary<string, Trainer>();
            string input = Console.ReadLine();

            while (input != "Tournament")
            {
                string[] inputParts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string trainerName = inputParts[0];
                string pokemonName = inputParts[1];
                string pokemonElement = inputParts[2];
                int pokemonHealth = int.Parse(inputParts[3]);

                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers[trainerName] = new Trainer(trainerName);
                }

                trainers[trainerName].Pokemons.Add(pokemon);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                switch (input)
                {
                    case "Fire":
                    case "Water":
                    case "Electricity":
                        CheckTrainer(trainers, input);
                        break;
                }

                input = Console.ReadLine();
            }

            foreach (var trainer in trainers.Values.OrderByDescending(t => t.Badges))
            {
                Console.WriteLine(trainer);
            }
        }

        private static void CheckTrainer(Dictionary<string, Trainer> trainers, string input)
        {
            foreach (var trainer in trainers.Values)
            {
                if (trainer.Pokemons.Any(p => p.Element == input))
                {
                    trainer.Badges++;
                }
                else
                {
                    foreach (var pokemon in trainer.Pokemons)
                    {
                        pokemon.Health -= 10;
                    }
                }
            }

            foreach (var trainer in trainers.Values)
            {
                for (int i = 0; i < trainer.Pokemons.Count; i++)
                {
                    if (trainer.Pokemons[i].Health <= 0)
                    {
                        trainer.Pokemons.RemoveAt(i);
                        i--;
                    }
                }
            }
        }
    }
}
