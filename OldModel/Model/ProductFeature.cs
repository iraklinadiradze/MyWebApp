using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ProductFeature
    {
        public long ProductFeatureId { get; set; }
        public long ProductId { get; set; }
        public int? FeatureId { get; set; }
        public long FeatureValueId { get; set; }

        public virtual FeatureValue FeatureValue { get; set; }
        public virtual Product1 Product { get; set; }
    }
}
