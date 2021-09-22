using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class PurchasePayment
    {
        public long PurchasePaymentId { get; set; }
        public long PurchaseId { get; set; }
        public DateTime TransDate { get; set; }
        public decimal? Amount { get; set; }
        public int? PurchasePaymentTypeId { get; set; }
        public bool? Posted { get; set; }
        public long? BankTransactionId { get; set; }
        public long? CashTransactionId { get; set; }
        public long? FinAccountId { get; set; }

        public virtual Purchase Purchase { get; set; }
    }
}
