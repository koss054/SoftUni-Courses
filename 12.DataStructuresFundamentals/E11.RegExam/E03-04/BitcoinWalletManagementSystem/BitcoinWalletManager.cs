using System;
using System.Collections.Generic;
using System.Linq;

namespace BitcoinWalletManagementSystem
{
    public class BitcoinWalletManager : IBitcoinWalletManager
    {
        private Dictionary<string, User> users = 
            new Dictionary<string, User>();

        private Dictionary<string, Wallet> wallets =
            new Dictionary<string, Wallet>();

        private Dictionary<string, List<Transaction>> userTransactions =
            new Dictionary<string, List<Transaction>>();

        private Dictionary<string, string> walletsForUser =
            new Dictionary<string, string>();

        public void CreateUser(User user)
        {
            users.Add(user.Id, user);
        }

        public void CreateWallet(Wallet wallet)
        {
            wallets.Add(wallet.Id, wallet);
            walletsForUser.Add(wallet.Id, wallet.UserId);
        }

        public bool ContainsUser(User user)
            => users.ContainsKey(user.Id);

        public bool ContainsWallet(Wallet wallet)
            => wallets.ContainsKey(wallet.Id);

        public IEnumerable<Wallet> GetWalletsByUser(string userId)
            => wallets.Values
                .Where(x => x.UserId == userId);
           

        public void PerformTransaction(Transaction transaction)
        {
            if (!wallets.ContainsKey(transaction.SenderWalletId)
                 || !wallets.ContainsKey(transaction.ReceiverWalletId)
                 || wallets[transaction.SenderWalletId].Balance < transaction.Amount)
                throw new ArgumentException();

            var senderWallet = wallets[transaction.SenderWalletId];
            var receiverWallet = wallets[transaction.ReceiverWalletId];
            var senderId = senderWallet.UserId;
            var receiverId = receiverWallet.UserId;

            senderWallet.Balance -= transaction.Amount;
            receiverWallet.Balance -= transaction.Amount;

            if (!userTransactions.ContainsKey(senderWallet.UserId))
                userTransactions.Add(senderId, new List<Transaction>());

            if (!userTransactions.ContainsKey(receiverWallet.UserId))
                userTransactions.Add(receiverId, new List<Transaction>());

            userTransactions[senderId].Add(transaction);
            userTransactions[receiverId].Add(transaction);
        }

        public IEnumerable<Transaction> GetTransactionsByUser(string userId)
            => userTransactions[userId];


        public IEnumerable<Wallet> GetWalletsSortedByBalanceDescending()
            => wallets.Values.OrderByDescending(x => x.Balance);

        public IEnumerable<User> GetUsersSortedByBalanceDescending()
        {
            var sortedWallets = wallets.Values
                .OrderByDescending(x => x.Balance);

            var userBalance = new Dictionary<string, long>();
            foreach (var wallet in sortedWallets)
            {
                if (!userBalance.ContainsKey(wallet.UserId))
                    userBalance.Add(wallet.UserId, 0);

                userBalance[wallet.UserId] += wallet.Balance;
            }

            var usersToReturn = new List<User>();
            foreach (var user in userBalance.OrderByDescending(x => x.Value))
                usersToReturn.Add(users[user.Key]);

            return usersToReturn;
        }
          

        public IEnumerable<User> GetUsersByTransactionCount()
        {
            var sortedUserKeys = userTransactions
                .OrderByDescending(x => x.Value.Count)
                .Select(x => x.Key);

            var usersToReturn = new List<User>();
            foreach (var sortedUserKey in sortedUserKeys)
                usersToReturn.Add(users[sortedUserKey]);

            return usersToReturn;
        }
    }
}