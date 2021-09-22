using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class AccountDimension
    {
        public AccountDimension()
        {
            Accounts = new HashSet<Account>();
        }

        public int AccountDimensionId { get; set; }
        public string AccountDimension1 { get; set; }
        public string Descrip { get; set; }
        public int? EntityId1 { get; set; }
        public int? EntityId2 { get; set; }
        public int? EntityId3 { get; set; }
        public int? EntityId4 { get; set; }
        public int? EntityId5 { get; set; }
        public int? EntityId6 { get; set; }

        public virtual Entity EntityId1Navigation { get; set; }
        public virtual Entity EntityId2Navigation { get; set; }
        public virtual Entity EntityId3Navigation { get; set; }
        public virtual Entity EntityId4Navigation { get; set; }
        public virtual Entity EntityId5Navigation { get; set; }
        public virtual Entity EntityId6Navigation { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
