using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Color
    {
        public Color()
        {
            Products = new HashSet<Product>();
        }

        public int ColorId { get; set; }
        public int? BrandId { get; set; }
        public string Color1 { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
