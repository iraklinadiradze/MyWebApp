using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class TransferOrder
    {
        public long TransferOrderId { get; set; }
        public int AccountId { get; set; }
        public int? ReceiverAccountId { get; set; }
        public string ReceiverBankCode { get; set; }
        public string ReceiverAccount { get; set; }
        public decimal? Amount { get; set; }
        public int? EntityId { get; set; }
        public long? EntityForeignId { get; set; }

        public virtual Account1 ReceiverAccountNavigation { get; set; }
    }
}
