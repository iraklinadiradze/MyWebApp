using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Company1
    {
        public Company1()
        {
            Purchases = new HashSet<Purchase>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string TaxCode { get; set; }
        public string Director { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
