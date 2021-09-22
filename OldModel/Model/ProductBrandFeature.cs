using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ProductBrandFeature
    {
        public long ProductBrandFeatureId { get; set; }
        public long? ProductId { get; set; }
        public int BrandFeatureId { get; set; }
        public string BrandFeatureValueId { get; set; }

        public virtual Product1 Product { get; set; }
    }
}
