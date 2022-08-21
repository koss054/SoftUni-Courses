using System;
using System.Collections.Generic;

namespace E01.UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalUsernames = int.Parse(Console.ReadLine());
            var usernames = new HashSet<string>();

            for (int i = 0; i < totalUsernames; i++)
            {
                string currentUsername = Console.ReadLine();
                usernames.Add(currentUsername);
            }

            foreach (var username in usernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}
