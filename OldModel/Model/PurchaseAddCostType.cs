using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class PurchaseAddCostType
    {
        public PurchaseAddCostType()
        {
            AllocSources = new HashSet<AllocSource>();
            PurchaseAddCosts = new HashSet<PurchaseAddCost>();
        }

        public int PurchaseAddCostTypeId { get; set; }
        public string PurchaseAddCostType1 { get; set; }
        public bool? Allocate { get; set; }

        public virtual ICollection<AllocSource> AllocSources { get; set; }
        public virtual ICollection<PurchaseAddCost> PurchaseAddCosts { get; set; }
    }
}
