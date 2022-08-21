using System;
using System.Collections.Generic;
using System.Linq;
using Telephony.Contracts;
using Telephony.Models;

namespace Telephony.Core
{
    public class Engine
    {
        private Smarthphone smarthphone;
        private IList<string> numbers;
        private IList<string> urls;

        public Engine()
        {
            this.smarthphone = new Smarthphone();
            this.numbers = new List<string>();
            this.urls = new List<string>();
        }

        public void Run()
        {
            this.numbers = Console.ReadLine().Split().ToList();
            this.urls = Console.ReadLine().Split().ToList();

            CallNumbers();
            BrowseUrls();
        }

        private void CallNumbers()
        {
            foreach (var number in this.numbers)
            {
                try
                {
                    Console.WriteLine(this.smarthphone.Call(number));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        private void BrowseUrls()
        {
            foreach (var url in this.urls)
            {
                try
                {
                    Console.WriteLine(this.smarthphone.Browse(url));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
