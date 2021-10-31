using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLib.Attributes;

using DataAccessLayer.Model.Product;
using DataAccessLayer.Model.Core;

namespace DataAccessLayer.Model.Account
{
    public partial class Transaction
    {
        public Transaction()
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

        public DateTime TransDate{ get; set; }

        public long? PostOrderRefId { get; set; }

        public int? ReferenceEntityId { get; set; }
        public long? ReferenceId { get; set; }

        public int? SubReferenceEntityId { get; set; }
        public long? SubReferenceId { get; set; }

        public int? RefVersion { get; set; }

        public long AccountId{ get; set; }

        public decimal increase { get; set; }
        public decimal decrease { get; set; }
        public decimal balance { get; set; }

        public bool Eod{ get; set; }

        public long AccountTranSeq { get; set; }

        public DateTime PostTime { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        [ForeignKey("ReferenceEntityId")]
        public virtual Entity ReferenceEntity { get; set; }

        [ForeignKey("SubReferenceEntityId")]
        public virtual Entity SubReferenceEntity { get; set; }

        [ForeignKey("PostOrderRefId")]
        public virtual TransactionOrder TransactionOrder { get; set; }

    }

}
