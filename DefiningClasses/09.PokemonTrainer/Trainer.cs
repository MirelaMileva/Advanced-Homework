using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        private string name;
        private int badge;
        private List<Pokemon> pokemons;
        public Trainer(string name, int badges)
        {
            this.Name = name;
            Pokemons = new List<Pokemon>();
            this.Badges = 0;
        }
        public string Name 
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int Badges 
        {
            get { return this.badge; }
            set { this.badge = value; } 
        }
        public List<Pokemon> Pokemons 
        {
            get { return this.pokemons; }
            set { this.pokemons = value; } 
        }

    }
}
