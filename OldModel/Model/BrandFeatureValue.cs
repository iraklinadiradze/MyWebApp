using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class BrandFeatureValue
    {
        public int BrandFeatureValueId { get; set; }
        public int BrandFeatureId { get; set; }
        public int? BrandId { get; set; }
        public string BrandFeatureValue1 { get; set; }

        public virtual Brand1 Brand { get; set; }
        public virtual BrandFeature BrandFeature { get; set; }
    }
}
