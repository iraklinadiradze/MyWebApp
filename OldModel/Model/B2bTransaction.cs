using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class B2bTransaction
    {
        public long B2bTransactionId { get; set; }
        public DateTime TransDate { get; set; }
        public int DebitAccountId { get; set; }
        public int CreditAccountId { get; set; }
        public long? DebitAccountStatementId { get; set; }
        public long? CreditAccountStatementId { get; set; }
        public decimal? Amount { get; set; }
        public string Note { get; set; }
        public int? DocumentTypeId { get; set; }
        public long? DocumentId { get; set; }

        public virtual Account1 CreditAccount { get; set; }
        public virtual Account1 DebitAccount { get; set; }
    }
}
