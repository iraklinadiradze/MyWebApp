using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class MovementDetail
    {
        public long MovementDetailId { get; set; }
        public long MovementId { get; set; }
        public long? InventoryId { get; set; }
        public decimal? QtyFrom { get; set; }
        public decimal? QtyTo { get; set; }
        public decimal? ValueFrom { get; set; }
        public decimal? ValueTo { get; set; }
        public long? QtyTransactionId { get; set; }
        public long? ValueTransactionId { get; set; }
        public bool? FromQtyPosted { get; set; }
        public bool? FromFinPosted { get; set; }
        public bool? ToFinPosted { get; set; }
        public bool? ToQtyPosted { get; set; }
        public int FromPosted { get; set; }
        public int ToPosted { get; set; }

        public virtual Inventory Inventory { get; set; }
        public virtual Movement1 Movement { get; set; }
    }
}
