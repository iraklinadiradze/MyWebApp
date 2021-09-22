using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Bank
    {
        public Bank()
        {
            Account1s = new HashSet<Account1>();
        }

        public int BankId { get; set; }
        public string Bankname { get; set; }
        public string Bankcode { get; set; }
        public string SwiftCode { get; set; }
        public string Address { get; set; }
        public string Swiftcode1 { get; set; }

        public virtual ICollection<Account1> Account1s { get; set; }
    }
}
