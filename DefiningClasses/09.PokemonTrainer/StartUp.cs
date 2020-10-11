using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input;
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            while ((input = Console.ReadLine()) != "Tournament")
            {
                AddTrainers(input, trainers);
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                GetPokemonElements(trainers, command);
            }

            trainers = trainers.OrderByDescending(t => t.Value.Badges).ToDictionary(a => a.Key, b => b.Value);

            foreach (var trainer in trainers)
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.Badges} {trainer.Value.Pokemons.Count}");
            }
        }

        private static void GetPokemonElements(Dictionary<string, Trainer> trainers, string command)
        {
            foreach ((string name, Trainer trainer) in trainers)
            {
                if (trainer.Pokemons.Any(p => p.Element == command))
                {
                    trainer.Badges++;
                }
                else
                {
                    trainer.Pokemons.ForEach(p => p.Health -= 10);
                    trainer.Pokemons.RemoveAll(p => p.Health <= 0);
                }
            }
        }

        private static void AddTrainers(string input, Dictionary<string, Trainer> trainers)
        {
            var inputInfo = input.Split();
            string trainerName = inputInfo[0];
            string pokemonName = inputInfo[1];
            string pokemonElement = inputInfo[2];
            int pokemonHealth = int.Parse(inputInfo[3]);

            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            if (!trainers.ContainsKey(trainerName))
            {
                Trainer trainer = new Trainer(trainerName, 0);
                trainers.Add(trainerName, trainer);
            }

            trainers[trainerName].Pokemons.Add(pokemon);
        }
    }
}
