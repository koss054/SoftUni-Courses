using System;
using System.Linq;
using System.Collections.Generic;

namespace L04.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var stores = new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                var userInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (userInput[0] == "Revision")
                {
                    break;
                }

                string storeName = userInput[0];
                string productName = userInput[1];
                double productPrice = double.Parse(userInput[2]);

                if (!stores.ContainsKey(storeName))
                {
                    stores.Add(storeName, new Dictionary<string, double>());
                }

                stores[storeName].Add(productName, productPrice);
            }

            var orderedStores = stores.OrderBy(s => s.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var store in orderedStores)
            {
                Console.WriteLine($"{store.Key}->");

                foreach (var product in store.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
