using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class TransactionOrder
    {
        public TransactionOrder()
        {
            Transactions = new HashSet<Transaction>();
        }

        public long OrderRefId { get; set; }
        public DateTime TransDate { get; set; }
        public int? ReferenceEntityId { get; set; }
        public long? ReferenceId { get; set; }
        public int? SubReferenceEntityId { get; set; }
        public long? SubReferenceId { get; set; }
        public DateTime? PostTime { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
