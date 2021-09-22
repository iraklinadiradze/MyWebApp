using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class StockCountDetail
    {
        public long StockCountDetailId { get; set; }
        public long StockCountId { get; set; }
        public long? InventoryId { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Value { get; set; }
        public long? QtyTransactionId { get; set; }
        public long? ValueTransactionId { get; set; }
        public bool? FinPosted { get; set; }
        public bool? QtyPosted { get; set; }
        public int Posted { get; set; }

        public virtual Inventory Inventory { get; set; }
        public virtual StockCount StockCount { get; set; }
    }
}
