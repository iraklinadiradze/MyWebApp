using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class CashOutOrder
    {
        public long CashOutOrderId { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public int? EntityId { get; set; }
        public long? EntityForeignId { get; set; }
    }
}
