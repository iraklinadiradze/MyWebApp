using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class StockWriteoff
    {
        public StockWriteoff()
        {
            StockWriteoffDetails = new HashSet<StockWriteoffDetail>();
        }

        public long StockWriteoffId { get; set; }
        public DateTime? TransDate { get; set; }
        public int? LocationId { get; set; }
        public bool? QtyPostedStarted { get; set; }
        public bool? FinPostedStarted { get; set; }
        public bool? FinPosted { get; set; }
        public bool? QtyPosted { get; set; }
        public int Posted { get; set; }

        public virtual ICollection<StockWriteoffDetail> StockWriteoffDetails { get; set; }
    }
}
