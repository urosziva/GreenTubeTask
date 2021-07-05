using GreenTubeTask.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenTubeTask.Models.Dtos
{
    public class TransactionDto
    {
        public string Id { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
    }
}
