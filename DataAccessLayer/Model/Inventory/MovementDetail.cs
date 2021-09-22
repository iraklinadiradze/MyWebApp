using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLib.Attributes;

using DataAccessLayer.Model.Product;

namespace DataAccessLayer.Model.Inventory
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
        
        [ForeignKey("Movement")]
        [FilterParam(equals = true, useInJoin = true)]
        public int MovementId { get; set; }

        [ForeignKey("Inventory")]
        [FilterParam(equals = true, useInJoin = true)]
        public int InventoryId { get; set; }

        public decimal? SendQty { get; set; }
        public decimal? SendValue { get; set; }

        public decimal? ReceiveQty { get; set; }
        public decimal? ReceiveValue { get; set; }

        public bool? SendQtyPosted { get; set; }
        public bool? SendFinPosted { get; set; }

        public bool? ReceiveQtyPosted { get; set; }
        public bool? ReceiveFinPosted { get; set; }
        
        public bool? SendPosted { get; set; }
        public bool? ReceivePosted { get; set; }

        public virtual Movement Movement { get; set; }
        public virtual Inventory Inventory { get; set; }

        //        public virtual ProductUnit ProductUnit { get; set; }

        //      public virtual ICollection<MovementDetail> MovementDetails { get; set; }
        //        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
        //        public virtual ICollection<Sale> Sales { get; set; }
        //        public virtual ICollection<StockCountDetail> StockCountDetails { get; set; }
        //        public virtual ICollection<StockWriteoffDetail> StockWriteoffDetails { get; set; }
    }

}
