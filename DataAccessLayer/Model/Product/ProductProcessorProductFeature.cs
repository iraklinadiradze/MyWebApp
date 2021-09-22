using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLib.Attributes;

namespace DataAccessLayer.Model.Product
{
    public partial class ProductProcessorProductFeature
    {
        public ProductProcessorProductFeature()
        {
//            ProductFeature = new HashSet<ProductFeature>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]
        public int Id { get; set; }

        [ForeignKey("ProductProcessorDetail")]
        public int ProductProcessorDetailId { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Feature Name is required")]
        public string FeatureName { get; set; }
        public int FeatureId { get; set; }

        public string FeatureValue{ get; set; }
        public int FeatureValueId { get; set; }
        public int FeatureValueIdDictionary { get; set; }

        public virtual ProductProcessorDetail ProductProcessorDetail { get; set; }

//        public virtual ICollection<ProductFeature> ProductFeature { get; set; }
    }

}
