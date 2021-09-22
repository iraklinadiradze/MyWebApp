using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            ProductGroups = new HashSet<ProductGroup>();
        }

        public int ProductCategoryId { get; set; }
        public string ProductCategoryCode { get; set; }
        public string ProductCategory1 { get; set; }

        public virtual ICollection<ProductGroup> ProductGroups { get; set; }
    }
}
