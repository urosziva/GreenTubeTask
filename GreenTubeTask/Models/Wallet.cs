using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenTubeTask.Models
{
    public class Wallet
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
