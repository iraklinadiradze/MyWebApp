using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ProductTemplate
    {
        public ProductTemplate()
        {
            Product1s = new HashSet<Product1>();
            ProductTemplateBrandFeatures = new HashSet<ProductTemplateBrandFeature>();
            ProductTemplateFeatures = new HashSet<ProductTemplateFeature>();
        }

        public int Id { get; set; }
        public string ProductTemplateCode { get; set; }
        public string ProductTemplateName { get; set; }
        public int ProductUnitId { get; set; }
        public bool? IsTangible { get; set; }
        public bool? IsSingle { get; set; }
        public bool? IsWholeQuantity { get; set; }

        public virtual ProductUnit ProductUnit { get; set; }
        public virtual ICollection<Product1> Product1s { get; set; }
        public virtual ICollection<ProductTemplateBrandFeature> ProductTemplateBrandFeatures { get; set; }
        public virtual ICollection<ProductTemplateFeature> ProductTemplateFeatures { get; set; }
    }
}
