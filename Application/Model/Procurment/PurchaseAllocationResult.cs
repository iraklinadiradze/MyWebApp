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
    public class PurchaseAllocationResult
    {

        public PurchaseAllocationResult()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]
        public int Id { get; set; }

        public int PurchaseAllocationSourceId { get; set; }

        public long PurchaseDetailId { get; set; }

        public decimal Amount{ get; set; }

        [ForeignKey("PurchaseAllocationSourceId")]
        public virtual PurchaseAllocationSource PurchaseAllocationSource { get; set; }

        [ForeignKey("PurchaseDetailId")]
        public virtual PurchaseDetail PurchaseDetail { get; set; }

    }
}
