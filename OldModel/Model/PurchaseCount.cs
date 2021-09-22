using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class PurchaseCount
    {
        public int PurchaseCountId { get; set; }
        public byte[] Version { get; set; }
        public long? PurchaseId { get; set; }
        public string BarCode { get; set; }
        public decimal? Qty { get; set; }

        public virtual Purchase Purchase { get; set; }
    }
}
