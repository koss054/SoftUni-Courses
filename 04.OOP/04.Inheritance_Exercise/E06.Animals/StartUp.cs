using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>();
            string animalType = Console.ReadLine();

            while (animalType != "Beast!")
            {
                string[] animalDetails = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (animalDetails.Length != 3 ||
                    int.Parse(animalDetails[1]) < 0)
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    string name = animalDetails[0];
                    int age = int.Parse(animalDetails[1]);
                    string gender = animalDetails[2];

                    switch (animalType)
                    {
                        case "Dog":
                            var dog = new Dog(name, age, gender);
                            animals.Add(dog);
                            break;
                        case "Frog":
                            var frog = new Frog(name, age, gender);
                            animals.Add(frog);
                            break;
                        case "Cat":
                            var cat = new Cat(name, age, gender);
                            animals.Add(cat);
                            break;
                        case "Kitten":
                            var kitten = new Kitten(name, age);
                            animals.Add(kitten);
                            break;
                        case "Tomcat":
                            var tomcat = new Tomcat(name, age);
                            animals.Add(tomcat);
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            break;
                    }
                }

                animalType = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
