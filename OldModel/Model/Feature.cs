using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Feature
    {
        public Feature()
        {
            FeatureValues = new HashSet<FeatureValue>();
            ProductTemplateFeatures = new HashSet<ProductTemplateFeature>();
        }

        public int FeatureId { get; set; }
        public string Feature1 { get; set; }
        public string FeatureCode { get; set; }

        public virtual ICollection<FeatureValue> FeatureValues { get; set; }
        public virtual ICollection<ProductTemplateFeature> ProductTemplateFeatures { get; set; }
    }
}
