using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Inventory
    {
        public Inventory()
        {
            MovementDetails = new HashSet<MovementDetail>();
            PurchaseDetails = new HashSet<PurchaseDetail>();
            Sales = new HashSet<Sale>();
            StockCountDetails = new HashSet<StockCountDetail>();
            StockWriteoffDetails = new HashSet<StockWriteoffDetail>();
        }

        public long InventoryId { get; set; }
        public long ProductId { get; set; }
        public string InventoryCode { get; set; }
        public bool? ProcInInventory { get; set; }
        public bool? IsSingle { get; set; }
        public bool? IsWholeQuantity { get; set; }
        public int? ProductUnitId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpDate { get; set; }
        public int? EntityId { get; set; }
        public long? EntityForeignId { get; set; }
        public string EntityProcCode { get; set; }

        public virtual ICollection<MovementDetail> MovementDetails { get; set; }
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<StockCountDetail> StockCountDetails { get; set; }
        public virtual ICollection<StockWriteoffDetail> StockWriteoffDetails { get; set; }
    }
}
