using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class PurchaseAddCost
    {
        public int PurchaseAddCostId { get; set; }
        public byte[] Version { get; set; }
        public long? PurchaseId { get; set; }
        public string InvoiceNumber { get; set; }
        public int? PurchaseAddCostTypeId { get; set; }
        public decimal? Amount { get; set; }
        public string Currency { get; set; }
        public decimal? Xrate { get; set; }
        public int? SupplierId { get; set; }

        public virtual Purchase Purchase { get; set; }
        public virtual PurchaseAddCostType PurchaseAddCostType { get; set; }
    }
}
