using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class TemplateOut
    {
        public long TemplateOutId { get; set; }
        public long TemplateId { get; set; }
        public int? DateShift { get; set; }
        public decimal? ValuePercentage { get; set; }
        public long? ProductId { get; set; }
        public decimal? Qty { get; set; }
        public bool? FinPosted { get; set; }
        public bool? QtyPosted { get; set; }
        public bool? Posted { get; set; }

        public virtual Template Template { get; set; }
    }
}
