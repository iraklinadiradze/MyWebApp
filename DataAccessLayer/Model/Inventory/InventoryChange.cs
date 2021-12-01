using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLib.Attributes;


namespace DataAccessLayer.Model.Inventory
{
    public partial class InventoryChange
    {
        public InventoryChange()
        {
//            MovementDetails = new HashSet<MovementDetail>();
//            PurchaseDetails = new HashSet<PurchaseDetail>();
//            Sales = new HashSet<Sale>();
//            StockCountDetails = new HashSet<StockCountDetail>();
//            StockWriteoffDetails = new HashSet<StockWriteoffDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]
        public long Id { get; set; }

        public DateTime TransDate { get; set; }

        [ForeignKey("Inventory")]
        public long InventoryId { get; set; }

        [ForeignKey("InventoryChangeType")]
        public int InventoryChangeTypeId { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }

        public decimal QtyIncrease { get; set; }
        public decimal QtyDecrease { get; set; }
        public decimal QtyBalance { get; set; }

        public decimal CostIncrease { get; set; }
        public decimal CostDecrease { get; set; }
        public decimal CostBalance { get; set; }

        public bool IsDayLastChange { get; set; }

        public int? EntityId { get; set; }
        public long? EntityForeignId { get; set; }
        public string EntityProcCode { get; set; }

        public long? ParentInventoryChangeId { get; set; }

        public DateTime TimeSequence { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual InventoryChangeType InventoryChangeType { get; set; }
        public virtual Location Location { get; set; }

        //      public virtual ICollection<MovementDetail> MovementDetails { get; set; }
        //        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
        //        public virtual ICollection<Sale> Sales { get; set; }
        //        public virtual ICollection<StockCountDetail> StockCountDetails { get; set; }
        //        public virtual ICollection<StockWriteoffDetail> StockWriteoffDetails { get; set; }
    }

}
