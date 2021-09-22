using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ErrorCode
    {
        public ErrorCode()
        {
            ErrorCodeLanguages = new HashSet<ErrorCodeLanguage>();
        }

        public long ErrorCodeId { get; set; }
        public string ErrorAreaType { get; set; }
        public string ErrorArea { get; set; }
        public string ErrorSubareaType { get; set; }
        public string ErrorSubarea { get; set; }
        public string ErrorCode1 { get; set; }

        public virtual ICollection<ErrorCodeLanguage> ErrorCodeLanguages { get; set; }
    }
}
