using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;

using Application.Model.Client;
using Application.Model.Core;
using Application.Model.Product;
using Application.Model.Inventory;

namespace Application.Model.Procurment
{
    public class PurchaseDetail
    {

        public PurchaseDetail()
        {
            //            MovementDetail = new HashSet<MovementDetail>();
            //            PurchaseDetails = new HashSet<PurchaseDetail>();
            //            Sales = new HashSet<Sale>();s
            //            StockCountDetails = new HashSet<StockCountDetail>();
            //            StockWriteoffDetails = new HashSet<StockWriteoffDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]
        public int Id { get; set; }

        public int PurchaseId { get; set; }

        public int ProductId { get; set; }

        [MaxLength(30)]
        public string InventoryCode { get; set; }

        [MaxLength(8)]
        public string PurchaseDraftVersion{ get; set; }

        public int PurchaseDraftId { get; set; }

        public int LocationId { get; set; }

        public decimal QtyInvoiced { get; set; }

        public decimal CostInvoiced { get; set; }
        public decimal VatInvoiced { get; set; }

        public decimal CostInvoicedWithoutVat { get; set; }
        public decimal CostInvoicedEqu { get; set; }

        public decimal QtyCalculated { get; set; }
        public decimal CostCalculated { get; set; }
        public decimal CostCalculatedEqu { get; set; }

        public int PurchaseDetailPostTypeId { get; set; }

        public bool QtyPosted { get; set; }
        public bool FinPosted { get; set; }
        public bool Posted { get; set; }

        public long InventoryId { get; set; }
        public int GlAccountId { get; set; }
        public int ProjectId { get; set; }

        public decimal AddCost { get; set; }
        public decimal FinalCost { get; set; }
        public decimal FinalQty { get; set; }
        public bool Allocated{ get; set; }
        public bool StockProductPerProcess { get; set; }

        [ForeignKey("PurchaseId")]
        public virtual Purchase Purchase { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product.Product Product { get; set; }

        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

        [ForeignKey("InventoryId")]
        public virtual Inventory.Inventory Inventory { get; set; }

        [ForeignKey("PurchaseDetailPostTypeId")]
        public virtual PurchaseDetailPostType PurchaseDetailPostType { get; set; }


    }
}
