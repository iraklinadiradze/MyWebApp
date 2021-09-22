using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Style
    {
        public Style()
        {
            Products = new HashSet<Product>();
        }

        public int StyleId { get; set; }
        public int? BrandId { get; set; }
        public string Style1 { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
