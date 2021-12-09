using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;

using Application.Model.Product;

namespace Application.Model.Account
{
    public partial class Account
    {
        public Account()
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

        public int AccountDimensionId { get; set; }

        public int? EntityForeignId1 { get; set; }
        public int? EntityForeignId2 { get; set; }
        public int? EntityForeignId3 { get; set; }
        public int? EntityForeignId4 { get; set; }
        public int? EntityForeignId5 { get; set; }
        public int? EntityForeignId6 { get; set; }


        [ForeignKey("AccountDimensionId")]
        public virtual AccountDimension AccountDimension { get; set; }

    }

}
