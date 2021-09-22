using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ErrorMessage
    {
        public int ErrorMessageId { get; set; }
        public string ErrorMessageDescrip { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? EntryDate { get; set; }
        public bool? Posted { get; set; }
        public string ErrorCode { get; set; }
        public int? ErrorStatementId1 { get; set; }
        public int? ErrorStatementId10 { get; set; }
        public int? ErrorStatementId2 { get; set; }
        public int? ErrorStatementId3 { get; set; }
        public int? ErrorStatementId4 { get; set; }
        public int? ErrorStatementId5 { get; set; }
        public int? ErrorStatementId6 { get; set; }
        public int? ErrorStatementId7 { get; set; }
        public int? ErrorStatementId8 { get; set; }
        public int? ErrorStatementId9 { get; set; }
    }
}
