using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class TemplateIn
    {
        public long TemplateInId { get; set; }
        public long TemplateId { get; set; }
        public long? ProductId { get; set; }
        public decimal? Qty { get; set; }
        public bool? FinPosted { get; set; }
        public bool? QtyPosted { get; set; }
        public bool? Posted { get; set; }

        public virtual Template Template { get; set; }
    }
}
