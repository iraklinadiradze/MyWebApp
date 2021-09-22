using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ProductionOut
    {
        public long ProductionOutId { get; set; }
        public long ProductionId { get; set; }
        public int? InventoryId { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Value { get; set; }
        public bool? FinPosted { get; set; }
        public bool? QtyPosted { get; set; }
        public bool? Posted { get; set; }

        public virtual Production Production { get; set; }
    }
}
