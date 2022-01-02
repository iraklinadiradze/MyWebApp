using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;

using Application.Model.Client;
using Application.Model.Core;
using Application.Model.Product;
using Application.Model.Inventory;

namespace Application.Model.Procurment
{
    public class PurchaseAllocationSource
    {

        public PurchaseAllocationSource()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]
        public int Id { get; set; }

        public long PurchaseId { get; set; }

        public int PurchaseAllocationSourceTypeId { get; set; }

        public long AllocPurchaseDetailId { get; set; }

        public int GlAccountId { get; set; }

        public int PurchaseAllocSchemaId { get; set; }

 //       public bool PostStarted { get; set; }
//        public bool Posted { get; set; }

        [ForeignKey("PurchaseId")]
        public virtual Purchase Purchase { get; set; }

        [ForeignKey("PurchaseAllocationSourceTypeId")]
        public virtual PurchaseAllocationSourceType PurchaseAllocationSourceType { get; set; }

        [ForeignKey("PurchaseAllocSchemaId")]
        public virtual PurchaseAllocationSchema PurchaseAllocationSchema { get; set; }

        [ForeignKey("AllocPurchaseDetailId")]
        public virtual PurchaseDetail PurchaseDetail { get; set; }

    }
}
