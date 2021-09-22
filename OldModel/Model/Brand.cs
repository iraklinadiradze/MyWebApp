using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Brand
    {
        public Brand()
        {
            ColorCodes = new HashSet<ColorCode>();
            Colors = new HashSet<Color>();
            Models = new HashSet<Model>();
            ProductLabels = new HashSet<ProductLabel>();
            Products = new HashSet<Product>();
            Sizes = new HashSet<Size>();
            Styles = new HashSet<Style>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public virtual ICollection<ColorCode> ColorCodes { get; set; }
        public virtual ICollection<Color> Colors { get; set; }
        public virtual ICollection<Model> Models { get; set; }
        public virtual ICollection<ProductLabel> ProductLabels { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Size> Sizes { get; set; }
        public virtual ICollection<Style> Styles { get; set; }
    }
}
