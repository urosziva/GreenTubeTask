using GreenTubeTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenTubeTask.Repositories.IRepositories
{
    public interface IWalletRepository
    {
        void SaveTransaction(Transaction transaction);
        Task<List<Transaction>> GetTransactionsForPlayer(string userGuid);
    }
}
