using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ProductLabel
    {
        public ProductLabel()
        {
            Products = new HashSet<Product>();
        }

        public int ProductLabelId { get; set; }
        public int? BrandId { get; set; }
        public string ProductLabel1 { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
