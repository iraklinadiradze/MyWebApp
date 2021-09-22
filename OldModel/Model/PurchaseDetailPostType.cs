using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class PurchaseDetailPostType
    {
        public PurchaseDetailPostType()
        {
            PurchaseDetails = new HashSet<PurchaseDetail>();
        }

        public int PurchaseDetailPostTypeId { get; set; }
        public string PurchaseDetailPostType1 { get; set; }

        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }
}
