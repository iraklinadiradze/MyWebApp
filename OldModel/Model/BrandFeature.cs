using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class BrandFeature
    {
        public BrandFeature()
        {
            BrandFeatureValues = new HashSet<BrandFeatureValue>();
        }

        public int BrandFeatureId { get; set; }
        public string BrandFeatureName { get; set; }
        public string BrandFeatureCode { get; set; }

        public virtual ICollection<BrandFeatureValue> BrandFeatureValues { get; set; }
    }
}
