using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ProductTemplateBrandFeature
    {
        public long ProductTemplateBrandFeatureId { get; set; }
        public int ProductTemplateId { get; set; }
        public int BrandFeatureId { get; set; }
        public bool? IsMandatory { get; set; }

        public virtual ProductTemplate ProductTemplate { get; set; }
    }
}
