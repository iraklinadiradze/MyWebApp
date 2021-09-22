using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Production
    {
        public Production()
        {
            ProductionInStds = new HashSet<ProductionInStd>();
            ProductionIns = new HashSet<ProductionIn>();
            ProductionOutStds = new HashSet<ProductionOutStd>();
            ProductionOuts = new HashSet<ProductionOut>();
        }

        public long ProductionId { get; set; }
        public long ProcessId { get; set; }
        public DateTime? TransDate { get; set; }
        public int? ProductionTypeId { get; set; }
        public int? LocationId { get; set; }
        public long TemplateId { get; set; }
        public string Decsrip { get; set; }
        public DateTime? InTransDate { get; set; }
        public DateTime? OutTransDate { get; set; }
        public bool? InQtyPostedStarted { get; set; }
        public bool? InFinPostedStarted { get; set; }
        public bool? OutQtyPostedStarted { get; set; }
        public bool? OutFinPostedStarted { get; set; }
        public bool? InFinPosted { get; set; }
        public bool? InQtyPosted { get; set; }
        public bool? OutFinPosted { get; set; }
        public bool? OutQtyPosted { get; set; }
        public int InPosted { get; set; }
        public int OutPosted { get; set; }
        public bool? FinPosted { get; set; }
        public bool? QtyPosted { get; set; }
        public bool? Posted { get; set; }

        public virtual Process Process { get; set; }
        public virtual ProductionType ProductionType { get; set; }
        public virtual Template Template { get; set; }
        public virtual ICollection<ProductionInStd> ProductionInStds { get; set; }
        public virtual ICollection<ProductionIn> ProductionIns { get; set; }
        public virtual ICollection<ProductionOutStd> ProductionOutStds { get; set; }
        public virtual ICollection<ProductionOut> ProductionOuts { get; set; }
    }
}
