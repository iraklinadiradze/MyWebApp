using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLib.Attributes;

using DataAccessLayer.Model.Client;
using DataAccessLayer.Model.Core;
using DataAccessLayer.Model.Product;
using DataAccessLayer.Model.Inventory;

namespace DataAccessLayer.Model.Procurment
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

        public int PurchaseDetailId { get; set; }

        public decimal Amount{ get; set; }

        [ForeignKey("PurchaseAllocationSourceId")]
        public virtual PurchaseAllocationSource PurchaseAllocationSource { get; set; }

        [ForeignKey("PurchaseDetailId")]
        public virtual PurchaseDetail PurchaseDetail { get; set; }

    }
}
