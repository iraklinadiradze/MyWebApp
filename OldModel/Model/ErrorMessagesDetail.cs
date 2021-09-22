using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ErrorMessagesDetail
    {
        public int ErrorMessagesDetailId { get; set; }
        public int? ErrorMessageId { get; set; }
        public string LanguageId { get; set; }
        public string ErrorMessage { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? EntryDate { get; set; }
        public bool? Posted { get; set; }
    }
}
