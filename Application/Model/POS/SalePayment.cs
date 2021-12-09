using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;

using Application.Model.Client;
using Application.Model.Core;

namespace Application.Model.Sale
{
    public class SalePayment
    {

        public SalePayment()
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

        public int PaymentTypeId { get; set; }

        public decimal AmountIn{ get; set; }
        public decimal AmountOut { get; set; }
        public decimal Amount { get; set; }

        public string Note { get; set; }

        public bool Posted { get; set; }

        [ForeignKey("SaleId ")]
        public virtual Sale Sale { get; set; }

        [ForeignKey("PaymentTypeId")]
        public virtual SalePaymentType SalePaymentType{ get; set; }

    }
}
