using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ProductProcessorProductBrandFeature
    {
        public long ProductProcessorProductBrandFeatureId { get; set; }
        public long ProductProcessorDetailId { get; set; }
        public int BrandFeatureId { get; set; }
        public string BrandFeatureCode { get; set; }
        public string BrandFeatureValue { get; set; }
        public int? BrandFeatureValueIdDictionary { get; set; }
        public int? BrandFeatureValueId { get; set; }

        public virtual ProductProcessorDetail ProductProcessorDetail { get; set; }
    }
}
