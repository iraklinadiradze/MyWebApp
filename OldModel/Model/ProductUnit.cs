using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ProductUnit
    {
        public ProductUnit()
        {
            Product1s = new HashSet<Product1>();
            ProductTemplates = new HashSet<ProductTemplate>();
            Products = new HashSet<Product>();
        }

        public int ProductUnitId { get; set; }
        public string ProductUnit1 { get; set; }

        public virtual ICollection<Product1> Product1s { get; set; }
        public virtual ICollection<ProductTemplate> ProductTemplates { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
