using E03.Raiding.Contracts;
using E03.Raiding.Models;
using System;
using System.Collections.Generic;

namespace E03.Raiding.Core
{
    public class Engine
    {
        List<IBaseHero> heroes;

        public Engine()
        {
            this.heroes = new List<IBaseHero>();
        }

        public void Run()
        {
            AddHeroes();

            int bossPower = int.Parse(Console.ReadLine());
            bossPower = StartRaid(bossPower);

            if (bossPower <= 0)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private int StartRaid(int bossPower)
        {
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                bossPower -= hero.Power;
            }

            return bossPower;
        }

        private void AddHeroes()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                IBaseHero currentHero = null;

                string currentName = Console.ReadLine();
                string currentType = Console.ReadLine();

                if (IsValidType(currentType))
                {
                    switch (currentType)
                    {
                        case "Druid":
                            currentHero = new Druid(currentName);
                            break;
                        case "Paladin":
                            currentHero = new Paladin(currentName);
                            break;
                        case "Rogue":
                            currentHero = new Rogue(currentName);
                            break;
                        case "Warrior":
                            currentHero = new Warrior(currentName);
                            break;
                    }

                    heroes.Add(currentHero);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                }
            }
        }

        public bool IsValidType(string heroType)
        {
            if (heroType == "Druid" || heroType == "Paladin" ||
                heroType == "Rogue" || heroType == "Warrior")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
