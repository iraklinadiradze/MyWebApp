using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLib.Attributes;

using DataAccessLayer.Model.Client;
using DataAccessLayer.Model.Core;
using DataAccessLayer.Model.Product;

namespace DataAccessLayer.Model.Sale
{
    public class SaleSchemaDetail
    {

        public SaleSchemaDetail()
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

        public int SaleSchemaId { get; set; }

        public int ProductId { get; set; } 

        public decimal Price { get; set; }
        public decimal Discount{ get; set; }

        public string Name { get; set; }

        [ForeignKey("SaleSchemaId")]
        public virtual SaleSchema SaleSchema { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product.Product Product { get; set; }

    }
}
