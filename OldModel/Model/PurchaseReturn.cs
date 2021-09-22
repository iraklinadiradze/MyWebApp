using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class PurchaseReturn
    {
        public long PurchaseReturnId { get; set; }
        public DateTime TransDate { get; set; }
        public long? Posted { get; set; }
    }
}
