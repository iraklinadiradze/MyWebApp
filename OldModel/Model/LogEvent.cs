using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class LogEvent
    {
        public long LogEventId { get; set; }
        public DateTime? Timestamp { get; set; }
        public int? ComponentId { get; set; }
        public int? LocationId { get; set; }
        public int? ErrorCodeId { get; set; }
        public string ContextObj { get; set; }
    }
}
