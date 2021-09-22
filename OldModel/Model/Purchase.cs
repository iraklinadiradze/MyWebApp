using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Purchase
    {
        public Purchase()
        {
            PurchaseAddCosts = new HashSet<PurchaseAddCost>();
            PurchaseCounts = new HashSet<PurchaseCount>();
            PurchaseDetails = new HashSet<PurchaseDetail>();
            PurchasePayments = new HashSet<PurchasePayment>();
        }

        public long PurchaseId { get; set; }
        public DateTime TransDate { get; set; }
        public string InvoiceNumber { get; set; }
        public int CompanyId { get; set; }
        public long ClientId { get; set; }
        public int CurrencyId { get; set; }
        public decimal? Xrate { get; set; }
        public bool? ProcInInventory { get; set; }
        public byte? PurchaseStatusId { get; set; }
        public string PurchaseName { get; set; }
        public string Note { get; set; }
        public decimal? TotalCostInvoiced { get; set; }
        public decimal? TotalCostInvoicedEqu { get; set; }
        public decimal? TotalAllocCost { get; set; }
        public decimal? TotalFinalCostEqu { get; set; }
        public bool? AllocStarted { get; set; }
        public bool? Allocated { get; set; }
        public bool? FinPostedStarted { get; set; }
        public bool? QtyPostedStarted { get; set; }
        public bool? FinPosted { get; set; }
        public bool? QtyPosted { get; set; }
        public int Posted { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? CreatedBy { get; set; }

        public virtual Supplier1 Client { get; set; }
        public virtual Company1 Company { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual PurchaseStatus PurchaseStatus { get; set; }
        public virtual ICollection<PurchaseAddCost> PurchaseAddCosts { get; set; }
        public virtual ICollection<PurchaseCount> PurchaseCounts { get; set; }
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
        public virtual ICollection<PurchasePayment> PurchasePayments { get; set; }
    }
}
