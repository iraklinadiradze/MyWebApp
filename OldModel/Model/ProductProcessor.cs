using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ProductProcessor
    {
        public ProductProcessor()
        {
            ProductProcessorDetails = new HashSet<ProductProcessorDetail>();
        }

        public long ProductProcessorId { get; set; }
        public long? PurchaseId { get; set; }
        public bool? IdentifyProducts { get; set; }
        public bool? RegisterBrandProps { get; set; }
        public bool? RegisterProducts { get; set; }
        public bool? IdentifyProductsAfterRegistration { get; set; }
        public bool? RegisterSalesPrices { get; set; }
        public bool? RegisterPurchaseDetails { get; set; }

        public virtual ICollection<ProductProcessorDetail> ProductProcessorDetails { get; set; }
    }
}
