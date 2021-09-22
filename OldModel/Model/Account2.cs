using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Account2
    {
        public Account2()
        {
            TransactionDetails = new HashSet<TransactionDetail>();
        }

        public long AccountId { get; set; }
        public string AccountCode { get; set; }
        public int? FinAccountId { get; set; }
        public string Description { get; set; }

        public virtual FinAccount FinAccount { get; set; }
        public virtual ICollection<TransactionDetail> TransactionDetails { get; set; }
    }
}
