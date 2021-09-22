using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Size
    {
        public Size()
        {
            Products = new HashSet<Product>();
        }

        public int SizeId { get; set; }
        public int? BrandId { get; set; }
        public string Size1 { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
