using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class TransactionDetail
    {
        public long TransactionDetail1 { get; set; }
        public long TransactionId { get; set; }
        public bool? IsDebit { get; set; }
        public long? AccountId { get; set; }
        public decimal? Amount { get; set; }

        public virtual Account2 Account { get; set; }
        public virtual Transaction1 Transaction { get; set; }
    }
}
