using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Account
    {
        public Account()
        {
            AccountBalances = new HashSet<AccountBalance>();
        }

        public long AccountId { get; set; }
        public int AccountDimensionId { get; set; }
        public int EntityForeignId1 { get; set; }
        public int EntityForeignId2 { get; set; }
        public int EntityForeignId3 { get; set; }
        public int EntityForeignId4 { get; set; }
        public int? EntityForeignId5 { get; set; }
        public int? EntityForeignId6 { get; set; }

        public virtual AccountDimension AccountDimension { get; set; }
        public virtual ICollection<AccountBalance> AccountBalances { get; set; }
    }
}
