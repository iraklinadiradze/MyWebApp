using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ProductLabel1
    {
        public long ProductLabelId { get; set; }
        public long ProductId { get; set; }
        public int BrandId { get; set; }
        public string ProductLabel { get; set; }

        public virtual Product1 Product { get; set; }
    }
}
