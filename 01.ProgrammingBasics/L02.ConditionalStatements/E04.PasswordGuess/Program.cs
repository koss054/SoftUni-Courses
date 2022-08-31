using System;

namespace E04.PasswordGuess
{
    class Program
    {
        static void Main(string[] args)
        {
            const string realPassword = "s3cr3t!P@ssw0rd";
            string userInput = Console.ReadLine();

            if (userInput == realPassword)
                Console.WriteLine("Welcome");
            else
                Console.WriteLine("Wrong password!");
        }
    }
}
