using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ErrorLog
    {
        public long ErrorLogId { get; set; }
        public string ErrorAreaType { get; set; }
        public string ErrorArea { get; set; }
        public string ErrorSubareaType { get; set; }
        public string ErrorSubarea { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorParams { get; set; }
        public string UserContext { get; set; }
        public DateTime? ErrorTime { get; set; }
        public long? CurrentContextId { get; set; }
    }
}
