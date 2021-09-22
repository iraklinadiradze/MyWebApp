using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLib.Attributes;

namespace DataAccessLayer.Model.Product
{
    public partial class ProductProcessor
    {
        public ProductProcessor()
        {
            ProductProcessorDetail = new HashSet<ProductProcessorDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]
        public int Id { get; set; }

        public int PurchaseId { get; set; }

        public bool IdentifyProducts { get; set; }
        public bool RegisterBrandProps { get; set; }
        public bool RegisterProducts { get; set; }
        public bool IdentifyProductsAfterRegistration { get; set; }
        public bool RegisterSalesPrices { get; set; }
        public bool RegisterPurchaseDetails { get; set; }

        //        public virtual ICollection<ProductFeature> ProductFeature { get; set; }
        public virtual ICollection<ProductProcessorDetail> ProductProcessorDetail { get; set; }

        
    }

}
