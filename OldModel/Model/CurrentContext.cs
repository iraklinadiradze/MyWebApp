using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class CurrentContext
    {
        public long CurrentContextId { get; set; }
        public string UserName { get; set; }
        public string AppName { get; set; }
        public string HostAddress { get; set; }
        public string OtherContextInfo { get; set; }
        public int? Spid { get; set; }
        public DateTime? EntryTime { get; set; }
    }
}
