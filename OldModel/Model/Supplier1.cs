using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Supplier1
    {
        public Supplier1()
        {
            Purchases = new HashSet<Purchase>();
        }

        public long SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public int? DefaultBrandId { get; set; }
        public string ContactPerson { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
