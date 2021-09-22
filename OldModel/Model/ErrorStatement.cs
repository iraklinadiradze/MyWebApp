using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ErrorStatement
    {
        public int ErrorStatementId { get; set; }
        public string ErrorStatementCode { get; set; }
        public string SqlStatement { get; set; }
        public string Descrip { get; set; }
        public string TestInPar { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? EntryDate { get; set; }
        public bool? Posted { get; set; }
    }
}
