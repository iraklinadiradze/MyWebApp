using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Cashdesk
    {
        public Cashdesk()
        {
            CashTransactions = new HashSet<CashTransaction>();
        }

        public int CashdeskId { get; set; }
        public int LocationId { get; set; }
        public string CashdeskName { get; set; }

        public virtual ICollection<CashTransaction> CashTransactions { get; set; }
    }
}
