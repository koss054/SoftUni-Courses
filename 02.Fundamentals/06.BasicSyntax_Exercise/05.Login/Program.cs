using System;

namespace fundamentalsLesson6
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = string.Empty;
            
            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }
            /*
            string password = new string(username.Reverse().ToArray());
            int strLenght = username.Length - 1;

            while (strLenght >= 0)
            {
                password = password + username[strLenght];
                strLenght--;
            }            
            */

            string loginAttempt = string.Empty;
            int attempts = 0;
            
            while (loginAttempt != password)
            {
                loginAttempt = Console.ReadLine();
                attempts++;

                if (attempts == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }

                if (loginAttempt != password)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
                else
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
            }

        }
    }
}