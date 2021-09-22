using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class PurchaseDetail
    {
        public long PurchaseDetailId { get; set; }
        public byte[] Version { get; set; }
        public long PurchaseId { get; set; }
        public int? ProductId { get; set; }
        public string InventoryCode { get; set; }
        public string PurchaseDraftVersion { get; set; }
        public long? PurchaseDraftId { get; set; }
        public int? LocationId { get; set; }
        public decimal? QtyInvoiced { get; set; }
        public decimal? CostInvoiced { get; set; }
        public decimal? VatInvoiced { get; set; }
        public decimal? CostInvoicedWoVat { get; set; }
        public decimal? CostInvoicedEqu { get; set; }
        public decimal? QtyCalced { get; set; }
        public decimal? CostCalced { get; set; }
        public decimal? CostCalcedEqu { get; set; }
        public int? PurchaseDetailPostTypeId { get; set; }
        public bool? QtyPosted { get; set; }
        public bool? FinPosted { get; set; }
        public int Posted { get; set; }
        public long? InventoryId { get; set; }
        public long? GlAccountId { get; set; }
        public int? ProjectId { get; set; }
        public long? PurchaseAllocationId { get; set; }
        public decimal? AddCost { get; set; }
        public decimal? FinalCost { get; set; }
        public bool? Allocated { get; set; }

        public virtual Inventory Inventory { get; set; }
        public virtual Purchase Purchase { get; set; }
        public virtual PurchaseAllocation PurchaseAllocation { get; set; }
        public virtual PurchaseDetailPostType PurchaseDetailPostType { get; set; }
    }
}
