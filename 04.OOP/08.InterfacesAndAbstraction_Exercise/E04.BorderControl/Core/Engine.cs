using BorderControl.Contracts;
using BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl.Core
{
    public class Engine
    {
        List<IIdentifiable> identifiables;

        public Engine()
        {
            this.identifiables = new List<IIdentifiable>();
        }

        public void Run()
        {
            string[] input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                AddIds(input);
                input = Console.ReadLine().Split();
            }

            GetFakeIds();
        }

        private void GetFakeIds()
        {
            string fakeIdDigits = Console.ReadLine();

            foreach (var identifiable in identifiables.Where(x => x.Id.EndsWith(fakeIdDigits)))
            {
                Console.WriteLine(identifiable.Id);
            }
        }

        private void AddIds(string[] input)
        {
            IIdentifiable identifiable = null;

            if (input.Length == 3)
            {
                string name = input[0];
                int age = int.Parse(input[1]);
                string id = input[2];

                Citizen citizen = new Citizen(name, age, id);
                identifiable = citizen;

            }
            else
            {
                string model = input[0];
                string id = input[1];

                Robot robot = new Robot(model, id);
                identifiable = robot;
            }

            identifiables.Add(identifiable);
        }
    }
}
