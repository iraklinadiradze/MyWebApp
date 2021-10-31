using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLib.Attributes;

using DataAccessLayer.Model.Product;

namespace DataAccessLayer.Model.GeneralLedger
{
    public partial class GlTransactionDetail
    {
        public GlTransactionDetail()
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

        public long TransactionId { get; set; }

        public long GlAccountId { get; set; }

        public string Description{ get; set; }

        public bool IsDebit{ get; set; }
        public decimal Amount{ get; set; }

        [ForeignKey("TransactionId")]
        public virtual GlTransaction GlTransaction { get; set; }

        [ForeignKey("GlAccountId")]
        public virtual GlAccount GlAccount { get; set; }

    }

}
