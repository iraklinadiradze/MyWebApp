using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class AccountType
    {
        public AccountType()
        {
            Account1s = new HashSet<Account1>();
        }

        public int AccountTypeId { get; set; }
        public string AccountType1 { get; set; }

        public virtual ICollection<Account1> Account1s { get; set; }
    }
}
