using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;

using Application.Model.Product;
using System.ComponentModel;

namespace Application.Model.Inventory
{
    public partial class MovementDetail
    {
        public MovementDetail()
        {
//            MovementDetails = new HashSet<MovementDetail>();
//            PurchaseDetails = new HashSet<PurchaseDetail>();
//            Sales = new HashSet<Sale>();s
//            StockCountDetails = new HashSet<StockCountDetail>();
//            StockWriteoffDetails = new HashSet<StockWriteoffDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]
        public int Id { get; set; }
        
        [FilterParam(equals = true, useInJoin = true)]
        public long MovementId { get; set; }

        [FilterParam(equals = true, useInJoin = true)]
        public long InventoryId { get; set; }

        [DefaultValue(0)]
        public decimal SendQty { get; set; }

        [DefaultValue(0)]
        public decimal SendCost { get; set; }

        [DefaultValue(0)]
        public decimal ReceiveQty { get; set; }

        [DefaultValue(false)]
        public decimal ReceiveCost { get; set; }

        [DefaultValue(false)]
        public bool SendQtyPosted { get; set; }

        [DefaultValue(false)]
        public bool SendCostPosted { get; set; }

        [DefaultValue(false)]
        public bool ReceiveQtyPosted { get; set; }

        [DefaultValue(false)]
        public bool ReceiveCostPosted { get; set; }

        [DefaultValue(false)]
        public bool SendPosted { get; set; }

        [DefaultValue(false)]
        public bool ReceivePosted { get; set; }

        [ForeignKey("MovementId")]
        public virtual Movement Movement { get; set; }

        [ForeignKey("InventoryId")]
        public virtual Inventory Inventory { get; set; }

        //        public virtual ProductUnit ProductUnit { get; set; }

        //      public virtual ICollection<MovementDetail> MovementDetails { get; set; }
        //        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
        //        public virtual ICollection<Sale> Sales { get; set; }
        //        public virtual ICollection<StockCountDetail> StockCountDetails { get; set; }
        //        public virtual ICollection<StockWriteoffDetail> StockWriteoffDetails { get; set; }
    }

}
