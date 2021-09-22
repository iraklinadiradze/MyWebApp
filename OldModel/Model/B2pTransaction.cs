using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class B2pTransaction
    {
        public long B2pTransactionId { get; set; }
        public int? AccountId { get; set; }
        public long? AccountStatementId { get; set; }
        public DateTime? TransDate { get; set; }
        public int? EntityId { get; set; }
        public long? EntityForeignId { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
        public int? DocumentTypeId { get; set; }
        public long? DocumentId { get; set; }

        public virtual Account1 Account { get; set; }
        public virtual AccountStatement AccountStatement { get; set; }
        public virtual DocumentType DocumentType { get; set; }
    }
}
