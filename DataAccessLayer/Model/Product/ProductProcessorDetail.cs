using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLib.Attributes;

namespace DataAccessLayer.Model.Product
{
    public partial class ProductProcessorDetail
    {
        public ProductProcessorDetail()
        {
            ProductProcessorProductFeature = new HashSet<ProductProcessorProductFeature>();
            ProductProcessorSalePrice = new HashSet<ProductProcessorSalePrice>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]
        public int Id { get; set; }

        //        [MaxLength(50)]
        //        [LookupDisplayAttribute]
        //        [FilterParam(startsWith = true, useInJoin = true)]
        //        [MaxLength(50)]
        //        [LookupDisplayAttribute]
        //        [FilterParam(startsWith = true, useInJoin = true)]
  
        [ForeignKey("ProductProcessor")]
        public int ProductProcessorId { get; set; }
        public int LocationId { get; set; }
        public string ProductCode { get; set; }
        public int? ProductId { get; set; }
        public decimal? Cost { get; set; }
        public decimal? Qty { get; set; }
        public string BrandName { get; set; }
        public int? BrandId { get; set; }
        public int? BrandIdDictionary { get; set; }
        public string ProductGroupName { get; set; }
        public int? ProductGroupId { get; set; }
        public int? ProductGroupIdDictionary { get; set; }
        public string ProductLabelName { get; set; }
        public int? ProductLabelId { get; set; }
        public int? ProductLabelIdDictionary { get; set; }

        public virtual ProductProcessor ProductProcessor { get; set; }

        public virtual ICollection<ProductProcessorProductFeature> ProductProcessorProductFeature { get; set; }
        public virtual ICollection<ProductProcessorSalePrice> ProductProcessorSalePrice { get; set; }
    }

}
