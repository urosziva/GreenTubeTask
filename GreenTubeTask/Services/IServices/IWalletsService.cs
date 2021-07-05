using GreenTubeTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenTubeTask.Services
{
    public interface IWalletsService
    {
        bool MakeTransaction(Transaction transaction, string userGuid);
        Task<List<Transaction>> GetTransactionsForPlayer(string userGuid);
    }
}
