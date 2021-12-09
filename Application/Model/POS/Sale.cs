using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;

using Application.Model.Client;
using Application.Model.Core;
using Application.Model.Inventory;

namespace Application.Model.Sale
{
    public class Sale
    {

        public Sale()
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

        [Required(ErrorMessage = "Transaction Date Is Null")]
        public DateTime TransDate { get; set; }

        public int ShopId { get; set; }

        public int OwnerId { get; set; }
        public int ConsultantId { get; set; }

        public string Note { get; set; }

        public bool FinPostStarted { get; set; }
        public bool QtyPostStarted { get; set; }

        public bool FinPosted { get; set; }
        public bool QtyPosted { get; set; }
        public bool PaymentPosted { get; set; }

        public bool Posted { get; set; }

        [ForeignKey("OwnerId")]
        public virtual User OwnerUser{ get; set; }

        [ForeignKey("ConsultantId")]
        public virtual User ConsultantUser { get; set; }

        [ForeignKey("ShopId")]
        public virtual  Location Shop{ get; set; }

        
    }
}
