using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class AllocSourceType
    {
        public AllocSourceType()
        {
            AllocSources = new HashSet<AllocSource>();
        }

        public int AllocSourceTypeId { get; set; }
        public string AllocSourceType1 { get; set; }

        public virtual ICollection<AllocSource> AllocSources { get; set; }
    }
}
