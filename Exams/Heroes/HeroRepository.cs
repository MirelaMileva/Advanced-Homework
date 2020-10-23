using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            data = new List<Hero>();
        }

        public int Count
            => this.data.Count;
        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            Hero hero = this.data.FirstOrDefault(h => h.Name == name);

            if (hero != null)
            {
                this.data.Remove(hero);
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            int highestStrength = int.MinValue;
            Hero hero = null;

            foreach (var currHero in this.data)
            {
                if (currHero.Item.Strength > highestStrength)
                {
                    highestStrength = currHero.Item.Strength;
                    hero = currHero;
                }
            }

            return hero;
        }

        public Hero GetHeroWithHighestAbility()
        {
            int highestAbility = int.MinValue;
            Hero hero = null;

            foreach (var currHero in this.data)
            {
                if (currHero.Item.Ability > highestAbility)
                {
                    highestAbility = currHero.Item.Ability;
                    hero = currHero;
                }
            }

            return hero;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            int highestIntelligence = int.MinValue;
            Hero hero = null;

            foreach (var currHero in this.data)
            {
                if (currHero.Item.Intelligence > highestIntelligence)
                {
                    highestIntelligence = currHero.Item.Intelligence;
                    hero = currHero;
                }
            }

            return hero;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var hero in this.data)
            {
                sb.AppendLine($"{hero}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
