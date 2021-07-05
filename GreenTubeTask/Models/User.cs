using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenTubeTask.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public Wallet Wallet { get; set; }
    }
}
