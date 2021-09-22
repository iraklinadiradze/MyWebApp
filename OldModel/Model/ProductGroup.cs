using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ProductGroup
    {
        public ProductGroup()
        {
            Product1s = new HashSet<Product1>();
            Products = new HashSet<Product>();
        }

        public int ProductGroupId { get; set; }
        public string ProductGroup1 { get; set; }
        public int? ProductCategoryId { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<Product1> Product1s { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
