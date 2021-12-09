using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;

using Application.Model.Product;

namespace Application.Model.Account
{
    public partial class AccountBalance
    {
        public AccountBalance()
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

        public long AccountId { get; set; }

        public DateTime TransDate{ get; set; }
        public decimal increase{ get; set; }
        public decimal decrease { get; set; }
        public decimal balance { get; set; }
        public int AccountBalanceCount { get; set; }
        public DateTime MaxPostTime{ get; set; }
        public int BalanceTransactionId { get; set; }


        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

    }

}
