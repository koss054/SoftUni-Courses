using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Engine
    {
        List<IAnimal> animals;

        public Engine()
        {
            animals = new List<IAnimal>();
        }

        public void Run()
        {
            while (true)
            {
                string[] animalInfo = Console.ReadLine().Split();

                if (animalInfo[0] == "End")
                {
                    break;
                }

                IAnimal animal = null;
                animal = AddAnimals(animalInfo, animal);
                animals.Add(animal);

                string[] foodInfo = Console.ReadLine().Split();

                string foodType = foodInfo[0];
                int foodQty = int.Parse(foodInfo[1]);

                Console.WriteLine(animal.AskForFood());

                if (!animal.EatFood(foodType, foodQty))
                {
                    Console.WriteLine($"{animal.GetType().Name} does not eat {foodType}!");
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private IAnimal AddAnimals(string[] animalInfo, IAnimal animal)
        {
            string animalType = animalInfo[0];
            string animalName = animalInfo[1];
            double animalWeight = double.Parse(animalInfo[2]);

            if (animalType == "Cat" || animalType == "Tiger")
            {
                string livingRegion = animalInfo[3];
                string breed = animalInfo[4];

                if (animalType == "Cat")
                {
                    animal = new Cat(animalName, animalWeight, livingRegion, breed);
                }
                else
                {
                    animal = new Tiger(animalName, animalWeight, livingRegion, breed);
                }
            }
            else if (animalType == "Hen" || animalType == "Owl")
            {
                double wingSize = double.Parse(animalInfo[3]);

                if (animalType == "Hen")
                {
                    animal = new Hen(animalName, animalWeight, wingSize);
                }
                else
                {
                    animal = new Owl(animalName, animalWeight, wingSize);
                }
            }
            else if (animalType == "Mouse" || animalType == "Dog")
            {
                string livingRegion = animalInfo[3];

                if (animalType == "Mouse")
                {
                    animal = new Mouse(animalName, animalWeight, livingRegion);
                }
                else
                {
                    animal = new Dog(animalName, animalWeight, livingRegion);
                }
            }

            return animal;
        }
    }
}
