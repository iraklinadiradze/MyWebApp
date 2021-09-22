using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Payment
    {
        public long PaymentId { get; set; }
        public long? OperationId { get; set; }
        public int? PaymentTypeId { get; set; }
        public decimal? AmountIn { get; set; }
        public decimal? AmountOut { get; set; }
        public decimal? Amount { get; set; }
        public bool? Posted { get; set; }

        public virtual Operation Operation { get; set; }
        public virtual PaymentType PaymentType { get; set; }
    }
}
