using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ProductTemplateFeature
    {
        public long ProductTemplateFeatureId { get; set; }
        public int ProductTemplateId { get; set; }
        public int FeatureId { get; set; }
        public bool? IsMandatory { get; set; }

        public virtual Feature Feature { get; set; }
        public virtual ProductTemplate ProductTemplate { get; set; }
    }
}
