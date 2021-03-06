using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;

using Application.Model.Client;
using Application.Model.Core;
using Application.Model.Product;
using Application.Model.Inventory;
using System.ComponentModel;

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
        public long Id { get; set; }
        public long PurchaseId { get; set; }

        public int ProductId { get; set; }

        [MaxLength(30)]
        public string InventoryCode { get; set; }

        [MaxLength(8)]
        public string PurchaseDraftVersion { get; set; }

        public int PurchaseDraftId { get; set; }

        public int LocationId { get; set; }

        [DefaultValue(0)]
        public decimal QtyInvoiced { get; set; }

        [DefaultValue(0)]
        public decimal CostInvoiced { get; set; }

        [DefaultValue(0)]
        public decimal VatInvoiced { get; set; }

        [DefaultValue(0)]
        public decimal CostInvoicedWithoutVat { get; set; }

        [DefaultValue(0)]
        public decimal CostInvoicedEqu { get; set; }

        [DefaultValue(0)]
        public decimal QtyCalculated { get; set; }

        [DefaultValue(0)]
        public decimal CostCalculated { get; set; }

        [DefaultValue(0)]
        public decimal CostCalculatedEqu { get; set; }

        public int PurchaseDetailPostTypeId { get; set; }

        [DefaultValue(false)]
        public bool QtyPosted { get; set; }

        [DefaultValue(false)]
        public bool CostPosted { get; set; }

        [DefaultValue(false)]
        public bool Posted { get; set; }

        public long InventoryId { get; set; }
        public int GlAccountId { get; set; }
        public int ProjectId { get; set; }

        [DefaultValue(0)]
        public decimal AddCost { get; set; }

        [DefaultValue(0)]
        public decimal FinalCost { get; set; }

        [DefaultValue(0)]
        public decimal FinalQty { get; set; }

        [DefaultValue(false)]
        public bool Allocated { get; set; }

        [DefaultValue(false)]
        public bool StockProductPerProcess { get; set; }


        [ForeignKey("PurchaseId")]
        public virtual Purchase Purchase { get; set; }

        [ForeignKey("InventoryId")]
        public virtual Inventory.Inventory Inventory { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product.Product Product { get; set; }

        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }


        [ForeignKey("PurchaseDetailPostTypeId")]
        public virtual PurchaseDetailPostType PurchaseDetailPostType { get; set; }

    }
}
