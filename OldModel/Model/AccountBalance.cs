using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class AccountBalance
    {
        public long AccountBalanceId { get; set; }
        public byte[] Timestamp { get; set; }
        public long AccountId { get; set; }
        public DateTime TransDate { get; set; }
        public decimal Increase { get; set; }
        public decimal Decrease { get; set; }
        public decimal? Balance { get; set; }
        public long? AccountBalanceCount { get; set; }
        public DateTime? MaxPostTime { get; set; }
        public long? BalanceTransactionId { get; set; }

        public virtual Account Account { get; set; }
    }
}
