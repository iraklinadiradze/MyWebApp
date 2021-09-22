using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class FinAccount
    {
        public FinAccount()
        {
            Account2s = new HashSet<Account2>();
        }

        public int FinAccountId { get; set; }
        public string FinAccountCode { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Account2> Account2s { get; set; }
    }
}
