using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class FeatureValue
    {
        public FeatureValue()
        {
            ProductFeatures = new HashSet<ProductFeature>();
        }

        public long FeatureValueId { get; set; }
        public int? FeatureId { get; set; }
        public string FeatureValue1 { get; set; }

        public virtual Feature Feature { get; set; }
        public virtual ICollection<ProductFeature> ProductFeatures { get; set; }
    }
}
