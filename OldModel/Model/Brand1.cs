using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Brand1
    {
        public Brand1()
        {
            BrandFeatureValues = new HashSet<BrandFeatureValue>();
            Product1s = new HashSet<Product1>();
        }

        public int BrandId { get; set; }
        public int? CompanyId { get; set; }
        public string BrandName { get; set; }

        public virtual ICollection<BrandFeatureValue> BrandFeatureValues { get; set; }
        public virtual ICollection<Product1> Product1s { get; set; }
    }
}
