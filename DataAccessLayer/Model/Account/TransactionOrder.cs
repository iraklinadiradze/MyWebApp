using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLib.Attributes;

using DataAccessLayer.Model.Product;
using DataAccessLayer.Model.Core;

namespace DataAccessLayer.Model.Account
{
    public partial class TransactionOrder
    {
        public TransactionOrder()
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

        public int? ReferenceEntityId { get; set; }
        public long? ReferenceId { get; set; }

        public int? SubReferenceEntityId { get; set; }
        public long? SubReferenceId { get; set; }

        public DateTime PostTime { get; set; }

        [ForeignKey("ReferenceEntityId")]
        public virtual Entity ReferenceEntity { get; set; }

        [ForeignKey("SubReferenceEntityId")]
        public virtual Entity SubReferenceEntity { get; set; }

    }

}
