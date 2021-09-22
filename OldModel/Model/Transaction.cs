using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Transaction
    {
        public long TransactionId { get; set; }
        public DateTime TransDate { get; set; }
        public long? PostOrderRefId { get; set; }
        public int ReferenceEntityId { get; set; }
        public long? ReferenceId { get; set; }
        public int? SubReferenceEntityId { get; set; }
        public long? SubReferenceId { get; set; }
        public byte[] RefVersion { get; set; }
        public long AccountId { get; set; }
        public decimal Increase { get; set; }
        public decimal Decrease { get; set; }
        public bool? Eod { get; set; }
        public decimal? Balance { get; set; }
        public long? AccountTranSeq { get; set; }
        public DateTime? PostTime { get; set; }

        public virtual TransactionOrder PostOrderRef { get; set; }
    }
}
