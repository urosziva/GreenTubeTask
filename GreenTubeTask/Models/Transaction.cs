using GreenTubeTask.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenTubeTask.Models
{
    public class Transaction
    {
        public string Id { get; set; }
        public string WalletId { get; set; }
        public Wallet Wallet { get; set; }
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
    }
}
