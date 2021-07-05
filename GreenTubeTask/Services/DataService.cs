using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenTubeTask.Enums;
using GreenTubeTask.Models;
using GreenTubeTask.Repositories;

namespace GreenTubeTask.Services
{
    public class DataService : IDataService
    {
        public async Task InitData(ApiContext context)
        {

            //Test user 1
            User pera = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Username = "pera"
            };
            context.Users.Add(pera);

            Wallet perasWallet = new Wallet()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = pera.Id,
                Balance = 100
            };
            context.Wallets.Add(perasWallet);

            Transaction perasTran = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                WalletId = perasWallet.Id,
                Type = TransactionType.Deposit,
                Amount = 100
            };
            context.Transactions.Add(perasTran);

            //Test user 2
            User mika = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Username = "mika"
            };
            context.Users.Add(mika);

            Wallet mikasWallet = new Wallet()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = mika.Id,
                Balance = 120
            };
            context.Wallets.Add(mikasWallet);

            Transaction mikasTran1 = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                WalletId = mikasWallet.Id,
                Type = TransactionType.Deposit,
                Amount = 100
            };
            Transaction mikasTran2 = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                WalletId = mikasWallet.Id,
                Type = TransactionType.Stake,
                Amount = 20
            };
            Transaction mikasTran3 = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                WalletId = mikasWallet.Id,
                Type = TransactionType.Win,
                Amount = 40
            };
            context.Transactions.Add(mikasTran1);
            context.Transactions.Add(mikasTran2);
            context.Transactions.Add(mikasTran3);

            await context.SaveChangesAsync();
        }
    }
}
