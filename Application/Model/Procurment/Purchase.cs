using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;

using Application.Model.Client;
using Application.Model.Core;
using System.ComponentModel;

namespace Application.Model.Procurment
{
    public class Purchase
    {

        public Purchase()
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
        public long Id { get; set; }

        [Required(ErrorMessage = "Transaction Date Is Null")]
        public DateTime TransDate { get; set; }

        [MaxLength(40)]
        public string InvoiceNumber { get; set; }

        public int ClientId { get; set; }

        public int CurrencyId { get; set; }

        [DefaultValue(0)]
        public decimal xrate { get; set; }

        public bool ProcInInventory { get; set; }

        public int PurchaseStatusId { get; set; }

        public string PurchaseName { get; set; }

        public string Note { get; set; }

        [DefaultValue(0)]
        public decimal TotalCostInvoiced { get; set; }

        [DefaultValue(0)]
        public decimal TotalCostInvoicedEqu { get; set; }

        [DefaultValue(0)]
        public decimal TotalAllocCost{ get; set; }

        [DefaultValue(0)]
        public decimal TotalFinalCostEqu { get; set; }

        [DefaultValue("false")]
        public bool AllocStarted { get; set; }

        [DefaultValue("false")]
        public bool Allocated { get; set; }

        [DefaultValue("false")]
        public bool CostPostStarted { get; set; }

        [DefaultValue("false")]
        public bool QtyPostStarted { get; set; }

        [DefaultValue("false")]
        public bool CostPosted { get; set; }

        [DefaultValue("false")]
        public bool QtyPosted { get; set; }

        [DefaultValue("false")]
        public bool Posted { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client.Client Client{ get; set; }

        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }


    }
}
