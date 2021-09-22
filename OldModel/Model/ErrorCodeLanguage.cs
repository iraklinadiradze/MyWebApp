using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ErrorCodeLanguage
    {
        public long ErrorCodeLanguageId { get; set; }
        public long? ErrorCodeId { get; set; }
        public int? LanguageId { get; set; }
        public string Message { get; set; }

        public virtual ErrorCode ErrorCode { get; set; }
        public virtual Language Language { get; set; }
    }
}
