using System;
using System.Collections.Generic;
using System.Linq;

namespace E03.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var peopleKvp = new Dictionary<string, Person>();
                var productsKvp = new Dictionary<string, Product>();

                string[] people = Console.ReadLine()
                      .Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
                string[] products = Console.ReadLine()
                    .Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < people.Length; i += 2)
                {
                    string name = people[i];
                    decimal money = decimal.Parse(people[i + 1]);

                    var person = new Person(name, money);
                    peopleKvp.Add(name, person);
                }

                for (int i = 0; i < products.Length; i += 2)
                {
                    string name = products[i];
                    decimal cost = decimal.Parse(products[i + 1]);

                    var product = new Product(name, cost);
                    productsKvp.Add(name, product);
                }

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] commandInfo = command.Split();

                    string personName = commandInfo[0];
                    string productName = commandInfo[1];

                    var person = peopleKvp[personName];
                    var product = productsKvp[productName];

                    bool isAdded = person.AddProduct(product);

                    if (!isAdded)
                    {
                        Console.WriteLine($"{personName} can't afford {productName}");
                    }
                    else
                    {
                        Console.WriteLine($"{personName} bought {productName}");
                    }

                    command = Console.ReadLine();
                }

                foreach (var (name, person) in peopleKvp)
                {
                    string productsInfo = person.Products.Count > 0
                        ? string.Join(", ", person.Products.Select(x => x.Name))
                        : "Nothing bought";

                    Console.WriteLine($"{name} - {productsInfo}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
