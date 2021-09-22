using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Transaction1
    {
        public Transaction1()
        {
            TransactionDetails = new HashSet<TransactionDetail>();
        }

        public long TransactionId { get; set; }
        public DateTime? TransDate { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TransactionDetail> TransactionDetails { get; set; }
    }
}
