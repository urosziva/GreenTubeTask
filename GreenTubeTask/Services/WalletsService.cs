using GreenTubeTask.Enums;
using GreenTubeTask.Models;
using GreenTubeTask.Repositories.IRepositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenTubeTask.Services
{
    public class WalletsService : IWalletsService
    {
        private readonly IWalletRepository walletRepository;
        private readonly IUserRepository userRepository;

        private static readonly ConcurrentDictionary<string, object> usersRunningTransactions = new ConcurrentDictionary<string, object>();
        private static readonly object dictionaryLock = new object();

        public WalletsService(IWalletRepository walletRepository, IUserRepository userRepository)
        {
            this.walletRepository = walletRepository;
            this.userRepository = userRepository;
        }

        public bool MakeTransaction(Transaction transaction, string userGuid)
        {
            lock (usersRunningTransactions.GetOrAdd(userGuid, new object()))
            {
                User user = userRepository.GetUserByGuid(userGuid);
                if (user == null)
                {
                    return false;
                }

                if (IsTransactionValid(transaction, user.Wallet.Balance))
                {
                    transaction.Id = Guid.NewGuid().ToString();
                    transaction.WalletId = user.Wallet.Id;

                    switch (transaction.Type)
                    {
                        case TransactionType.Deposit:
                        case TransactionType.Win:
                            user.Wallet.Balance += transaction.Amount;
                            break;
                        case TransactionType.Stake:
                            user.Wallet.Balance -= transaction.Amount;
                            break;
                        default:
                            break;
                    }

                    walletRepository.SaveTransaction(transaction);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<List<Transaction>> GetTransactionsForPlayer(string userGuid)
        {
            return await walletRepository.GetTransactionsForPlayer(userGuid);
        }

        private bool IsTransactionValid(Transaction transaction, decimal userBalance)
        {
            if (transaction.Type == TransactionType.Stake)
            {
                return userBalance >= transaction.Amount;
            }
            else
            {
                return true;
            }
        }
    }
}
