using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Process
    {
        public Process()
        {
            Productions = new HashSet<Production>();
        }

        public long ProcessId { get; set; }
        public int? ProcessTypeId { get; set; }

        public virtual ProcessType ProcessType { get; set; }
        public virtual ICollection<Production> Productions { get; set; }
    }
}
