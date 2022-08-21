using System;
using System.Collections.Generic;

namespace L08.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var reservations = new HashSet<string>();
            bool hasEnded = false;
            bool hasStarted = false;
            int guestsMissing = 0;

            while (!hasEnded)
            {
                string currentInput = Console.ReadLine();

                if (currentInput == "END")
                {
                    hasEnded = true;
                    break;
                }

                if (hasStarted)
                {
                    reservations.Remove(currentInput);
                }
                else if (currentInput != "PARTY" && !hasStarted)
                {
                    reservations.Add(currentInput);
                }

                if (currentInput == "PARTY")
                {
                    hasStarted = true;
                }
            }

            guestsMissing = reservations.Count;

            Console.WriteLine(guestsMissing);

            foreach (var vipGuestsNotComing in reservations)
            {
                char[] digitOrLetter = vipGuestsNotComing.ToCharArray();

                if (char.IsDigit(digitOrLetter[0]))
                {
                    Console.WriteLine(vipGuestsNotComing);
                }
            }

            foreach (var notComing in reservations)
            {
                char[] digitOrLetter = notComing.ToCharArray();

                if (char.IsLetter(digitOrLetter[0]))
                {
                    Console.WriteLine(notComing);
                }
            }
        }
    }
}
