using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ProductionType
    {
        public ProductionType()
        {
            Productions = new HashSet<Production>();
        }

        public int ProductionTypeId { get; set; }
        public string ProductionTypeName { get; set; }
        public bool? Posted { get; set; }

        public virtual ICollection<Production> Productions { get; set; }
    }
}
