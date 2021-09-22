using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class PurchaseStatus
    {
        public PurchaseStatus()
        {
            Purchases = new HashSet<Purchase>();
        }

        public byte PurchaseStatusId { get; set; }
        public string PurchaseStatus1 { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
