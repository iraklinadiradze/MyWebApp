using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class PurchaseAllocation
    {
        public PurchaseAllocation()
        {
            PurchaseDetails = new HashSet<PurchaseDetail>();
        }

        public long PurchaseAllocationId { get; set; }
        public DateTime TransDate { get; set; }
        public bool? PostedStarted { get; set; }
        public bool? Posted { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }
}
