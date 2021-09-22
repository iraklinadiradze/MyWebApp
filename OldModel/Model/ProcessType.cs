using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ProcessType
    {
        public ProcessType()
        {
            Processes = new HashSet<Process>();
        }

        public int ProcessTypeId { get; set; }
        public string ProcessType1 { get; set; }

        public virtual ICollection<Process> Processes { get; set; }
    }
}
