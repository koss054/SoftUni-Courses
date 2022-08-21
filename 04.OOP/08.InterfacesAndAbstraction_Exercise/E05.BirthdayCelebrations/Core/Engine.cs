using BirthdayCelebrations.Contracts;
using BirthdayCelebrations.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl.Core
{
    public class Engine
    {
        List<IBirthable> birthables;

        public Engine()
        {
            this.birthables = new List<IBirthable>();
        }

        public void Run()
        {
            string[] input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                AddBirthdays(input);
                input = Console.ReadLine().Split();
            }

            GetBirthdate();
        }

        private void GetBirthdate()
        {
            string searchedYear = Console.ReadLine();

            foreach (var birthable in birthables.Where(x => x.Birthdate.EndsWith(searchedYear)))
            {
                Console.WriteLine(birthable.Birthdate);
            }
        }

        private void AddBirthdays(string[] input)
        {
            IBirthable birthable = null;
            string type = input[0];

            switch (type)
            {
                case "Citizen":
                    string citizenName = input[1];
                    int citizenAge = int.Parse(input[2]);
                    string citizenId = input[3];
                    string citizenBirthdate = input[4];

                    Citizen citizen = new Citizen(citizenName, citizenAge, citizenId, citizenBirthdate);
                    birthable = citizen;
                    break;

                case "Robot":
                    string robotModel = input[1];
                    string robotId = input[2];
                    break;

                case "Pet":
                    string petName = input[1];
                    string petBirthdate = input[2];

                    Pet pet = new Pet(petName, petBirthdate);
                    birthable = pet;
                    break;
            }

            if (birthable != null)
            {
                birthables.Add(birthable);
            }
        }
    }
}
