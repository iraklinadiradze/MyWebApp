using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class AllocSource
    {
        public long AllocSourceId { get; set; }
        public long PurchaseAllocationId { get; set; }
        public int? PurchaseAddCostTypeId { get; set; }
        public int? AllocSourceTypeId { get; set; }
        public long? AllocPurchaseDetailId { get; set; }
        public long? InventoryId { get; set; }
        public int? LocationId { get; set; }
        public long? GlAccountId { get; set; }
        public decimal? Amount { get; set; }
        public long? PurchaseDetailFinAccountId { get; set; }
        public string GlAccountFinAccountJd { get; set; }
        public bool? Allocate { get; set; }
        public bool? Posted { get; set; }

        public virtual AllocSourceType AllocSourceType { get; set; }
        public virtual PurchaseAddCostType PurchaseAddCostType { get; set; }
    }
}
