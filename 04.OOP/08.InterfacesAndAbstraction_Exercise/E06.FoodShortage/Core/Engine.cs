using FoodShortage.Contracts;
using FoodShortage.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace FoodShortage.Core
{
    class Engine
    {
        private List<IBuyer> buyers;
        private int totalFood;

        public Engine()
        {
            this.buyers = new List<IBuyer>();
            this.totalFood = 0;
        }

        public void Run()
        {
            AddBuyers();
            BuyFood();
            Console.WriteLine(this.totalFood);
        }

        private void BuyFood()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                IBuyer buyer = this.buyers.FirstOrDefault(x => x.Name == input);

                if (buyer != null)
                {
                    totalFood = buyer.BuyFood(totalFood);
                }

                input = Console.ReadLine();
            }
        }

        private void AddBuyers()
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                IBuyer buyer = null;

                string[] currentPersonDetails = Console.ReadLine().Split();
                string personName = currentPersonDetails[0];
                int personAge = int.Parse(currentPersonDetails[1]);

                if (currentPersonDetails.Length == 3)
                {
                    string rebelGroup = currentPersonDetails[2];

                    Rebel rebel = new Rebel(personName, personAge, rebelGroup);
                    buyer = rebel;
                }
                else
                {
                    string citizenId = currentPersonDetails[2];
                    string citizenBirthdate = currentPersonDetails[3];

                    Citizen citizen = new Citizen(personName, personAge, citizenId, citizenBirthdate);
                    buyer = citizen;
                }

                this.buyers.Add(buyer);
            }
        }
    }
}
