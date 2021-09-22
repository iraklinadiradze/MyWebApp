using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class CashTransaction
    {
        public long CashTransactionId { get; set; }
        public int CashdeskId { get; set; }
        public DateTime TransDate { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }

        public virtual Cashdesk Cashdesk { get; set; }
    }
}
