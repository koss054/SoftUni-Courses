using System;
using System.Collections.Generic;

namespace L06.MoneyTransactions
{
    class Program
    {
        static void Main(string[] args)
        {
            var bankAccounts = new Dictionary<int, double>();
            string[] accountsInfo = Console.ReadLine().Split(",");

            for (int i = 0; i < accountsInfo.Length; i++)
            {
                string[] currentAccountInfo = accountsInfo[i].Split("-");

                int accountNumber = int.Parse(currentAccountInfo[0]);
                double accountBalance = double.Parse(currentAccountInfo[1]);

                bankAccounts.Add(accountNumber, accountBalance);
            }

            string[] input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                try
                {
                    int accountNumber = int.Parse(input[1]);
                    double sum = double.Parse(input[2]);

                    if (input[0] == "Deposit")
                    {
                        if (!bankAccounts.ContainsKey(accountNumber))
                        {
                            throw new Exception("Invalid account!");
                        }
                        bankAccounts[accountNumber] += sum;
                    }
                    else if (input[0] == "Withdraw")
                    {
                        if (bankAccounts[accountNumber] - sum < 0)
                        {
                            throw new Exception("Insufficient balance!");
                        }
                        bankAccounts[accountNumber] -= sum;
                    }
                    else
                    {
                        throw new Exception("Invalid command!");
                    }

                    Console.WriteLine($"Account {accountNumber} has new balance: {bankAccounts[accountNumber]:F2}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    input = EndOfCommand();
                }
            }
        }

        private static string[] EndOfCommand()
        {
            string[] input;
            Console.WriteLine("Enter another command");
            input = Console.ReadLine().Split();
            return input;
        }
    }
}
