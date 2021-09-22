using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ProductProcessorProductFeature
    {
        public long ProductProcessorProductFeatureId { get; set; }
        public long ProductProcessorDetailId { get; set; }
        public int FeatureId { get; set; }
        public string FeatureCode { get; set; }
        public string FeatureValue { get; set; }
        public int? FeatureValueIdDictionary { get; set; }
        public int? FeatureValueId { get; set; }

        public virtual ProductProcessorDetail ProductProcessorDetail { get; set; }
    }
}
