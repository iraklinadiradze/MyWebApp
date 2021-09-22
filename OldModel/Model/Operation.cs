using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Operation
    {
        public Operation()
        {
            Payments = new HashSet<Payment>();
            Sales = new HashSet<Sale>();
        }

        public long OperationId { get; set; }
        public DateTime? TransDate { get; set; }
        public int? ShopId { get; set; }
        public int? OwnerId { get; set; }
        public int? ConsultantId { get; set; }
        public bool? FinPostedStarted { get; set; }
        public bool? QtyPostedStarted { get; set; }
        public bool? QtyPosted { get; set; }
        public bool? StockFinPosted { get; set; }
        public bool? SalesFinPosted { get; set; }
        public bool? PmtFinPosted { get; set; }
        public int Posted { get; set; }

        public virtual Location1 Shop { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
