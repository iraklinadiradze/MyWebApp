using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Product1
    {
        public Product1()
        {
            ProductBrandFeatures = new HashSet<ProductBrandFeature>();
            ProductFeatures = new HashSet<ProductFeature>();
            ProductLabel1s = new HashSet<ProductLabel1>();
        }

        public long ProductId { get; set; }
        public int? CompanyId { get; set; }
        public string ProductName { get; set; }
        public int? ProductGroupId { get; set; }
        public string BarCode { get; set; }
        public int? BrandId { get; set; }
        public bool? IsTangible { get; set; }
        public bool? IsSingle { get; set; }
        public bool? IsWholeQuantity { get; set; }
        public int? ProductTemplateId { get; set; }
        public int? ProductUnitId { get; set; }
        public long? ProductLabelId { get; set; }

        public virtual Brand1 Brand { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
        public virtual ProductTemplate ProductTemplate { get; set; }
        public virtual ProductUnit ProductUnit { get; set; }
        public virtual ICollection<ProductBrandFeature> ProductBrandFeatures { get; set; }
        public virtual ICollection<ProductFeature> ProductFeatures { get; set; }
        public virtual ICollection<ProductLabel1> ProductLabel1s { get; set; }
    }
}
