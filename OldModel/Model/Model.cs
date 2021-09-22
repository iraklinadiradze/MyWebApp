using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Model
    {
        public Model()
        {
            Products = new HashSet<Product>();
        }

        public int ModelId { get; set; }
        public int? BrandId { get; set; }
        public string Model1 { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
