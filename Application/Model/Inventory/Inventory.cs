using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;

using Application.Model.Product;

namespace Application.Model.Inventory
{
    public partial class Inventory
    {
        public Inventory()
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
        public long Id { get; set; }

        public int ProductId { get; set; }

        [MaxLength(50)]
        [LookupDisplayAttribute]
        [FilterParam(startsWith = true, useInJoin = true)]
        [Required(ErrorMessage = "Inventory Code is required")]
        public string InventoryCode { get; set; }
        public bool? ProcInInventory { get; set; }
        public bool? IsSingle { get; set; }
        public bool? IsWholeQuantity { get; set; }

        [ForeignKey("ProductUnit")]
        public int? ProductUnitId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpDate { get; set; }
        public int? EntityId { get; set; }
        public long? EntityForeignId { get; set; }
        public string EntityProcCode { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product.Product Product { get; set; }

//        public virtual ProductUnit ProductUnit { get; set; }

        //      public virtual ICollection<MovementDetail> MovementDetails { get; set; }
        //        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
        //        public virtual ICollection<Sale> Sales { get; set; }
        //        public virtual ICollection<StockCountDetail> StockCountDetails { get; set; }
        //        public virtual ICollection<StockWriteoffDetail> StockWriteoffDetails { get; set; }
    }

}