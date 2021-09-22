using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class AccountStatement
    {
        public AccountStatement()
        {
            B2pTransactions = new HashSet<B2pTransaction>();
        }

        public long AccountStatementId { get; set; }
        public int AccountId { get; set; }
        public DateTime TransDate { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
        public decimal? CorrAccount { get; set; }
        public string Note { get; set; }
        public string BankTransactionId { get; set; }

        public virtual Account1 Account { get; set; }
        public virtual ICollection<B2pTransaction> B2pTransactions { get; set; }
    }
}
