using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLib.Attributes;

using DataAccessLayer.Model.Client;
using DataAccessLayer.Model.Core;

namespace DataAccessLayer.Model.Procurment
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
        public int Id { get; set; }

        [Required(ErrorMessage = "Transaction Date Is Null")]
        public DateTime TransDate { get; set; }

        [MaxLength(40)]
        public string InvoiceNumber { get; set; }

        public int ClientId { get; set; }

        public int CurrencyId { get; set; }

        public decimal xrate { get; set; }

        public bool ProcInInventory { get; set; }

        public int PurchaseStatusId { get; set; }

        public string PurchaseName { get; set; }

        public string Note { get; set; }

        public decimal TotalCostInvoiced { get; set; }

        public decimal TotalCostInvoicedEqu { get; set; }

        public decimal TotalAllocCost{ get; set; }

        public decimal TotalFinalCostEqu { get; set; }

        public bool AllocStarted { get; set; }

        public bool Allocated { get; set; }

        public bool FinPostStarted { get; set; }

        public bool QtyPostStarted { get; set; }

        public bool FinPosted { get; set; }

        public bool QtyPosted { get; set; }

        public bool Posted { get; set; }


        [ForeignKey("ClientId")]
        public virtual Client.Client Client{ get; set; }

        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }


    }
}
