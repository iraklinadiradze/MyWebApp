using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;

using Application.Model.Client;
using Application.Model.Core;

namespace Application.Model.Sale
{
    public class SaleProduct
    {

        public SaleProduct()
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

        public int SaleId { get; set; }

        public long InventoryId { get; set; }
        public decimal Qty { get; set; }
        public decimal NominalPrice{ get; set; }
        public decimal NominalPriceDiscount { get; set; }
        public decimal SchemaPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal VatRate { get; set; }
        public decimal Cogs { get; set; }
        public decimal Revenue { get; set; }
        public decimal VatAmount { get; set; }


        public int OwnerId { get; set; }
        public int ConsultantId { get; set; }

        public string Note { get; set; }

        public bool FinPostStarted { get; set; }
        public bool QtyPostStarted { get; set; }

        public bool FinPosted { get; set; }
        public bool QtyPosted { get; set; }

        public bool Posted { get; set; }

        [ForeignKey("SaleId ")]
        public virtual Sale Sale { get; set; }

        [ForeignKey("InventoryId")]
        public virtual Inventory.Inventory SaleInventory { get; set; }

    }
}
