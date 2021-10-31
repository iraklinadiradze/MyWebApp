using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLib.Attributes;

using DataAccessLayer.Model.Product;
using DataAccessLayer.Model.Core;

namespace DataAccessLayer.Model.Account
{
    public partial class AccountDimension
    {
        public AccountDimension()
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
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description{ get; set; }

        public int? EntityId1 { get; set; }
        public int? EntityId2 { get; set; }
        public int? EntityId3 { get; set; }
        public int? EntityId4 { get; set; }
        public int? EntityId5 { get; set; }
        public int? EntityId6 { get; set; }

        [ForeignKey("EntityId1")]
        public virtual Entity Entity1 { get; set; }

        [ForeignKey("EntityId2")]
        public virtual Entity Entity2 { get; set; }

        [ForeignKey("EntityId3")]
        public virtual Entity Entity3 { get; set; }

        [ForeignKey("EntityId4")]
        public virtual Entity Entity4 { get; set; }

        [ForeignKey("EntityId5")]
        public virtual Entity Entity5 { get; set; }

        [ForeignKey("EntityId6")]
        public virtual Entity Entity6 { get; set; }

    }

}
