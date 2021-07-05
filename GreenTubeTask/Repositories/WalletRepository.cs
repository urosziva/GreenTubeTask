using GreenTubeTask.Models;
using GreenTubeTask.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenTubeTask.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly ApiContext dbContext;

        public WalletRepository(ApiContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void SaveTransaction(Transaction transaction)
        {
            dbContext.Transactions.Add(transaction);
            dbContext.SaveChanges();
        }

        public async Task<List<Transaction>> GetTransactionsForPlayer(string userGuid)
        {
            Wallet wallet = await dbContext.Wallets.Include(w => w.Transactions).FirstOrDefaultAsync(w => w.UserId == userGuid);
            if (wallet == null)
            {
                return new List<Transaction>();
            }

            return wallet.Transactions;
        }
    }
}
