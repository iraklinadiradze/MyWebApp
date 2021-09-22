using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ColorCode
    {
        public ColorCode()
        {
            Products = new HashSet<Product>();
        }

        public int ColorCodeId { get; set; }
        public int? BrandId { get; set; }
        public string ColorCode1 { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
