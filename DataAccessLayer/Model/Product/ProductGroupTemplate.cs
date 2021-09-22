using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLib.Attributes;

namespace DataAccessLayer.Model.Product
{
    public partial class ProductGroupTemplate
    {
        public ProductGroupTemplate()
        {
            ProductGroup = new HashSet<ProductGroup>();
            ProductGroupTemplateFeature = new HashSet<ProductGroupTemplateFeature>();
//            ProductTemplateFeatures = new HashSet<ProductTemplateFeature>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]
        public int Id { get; set; }


        [MaxLength(200)]
        [LookupDisplayAttribute]
        [FilterParam(startsWith = true, useInJoin = true)]
        [Required(ErrorMessage = "Product Group Template Name is required")]
        public string ProductGroupTemplateName { get; set; }

        [FilterParam(equals = true)]
        [ForeignKey("ProductUnit")]
        [Required(ErrorMessage = "Product Unit Id is required")]
        public int ProductUnitId { get; set; }

        public bool? IsTangible { get; set; }

        public bool? IsSingle { get; set; }

        public bool? IsWholeQuantity { get; set; }

        public virtual ProductUnit ProductUnit { get; set; }

        //        public virtual ICollection<Product1> Product1s { get; set; }
        //        public virtual ICollection<ProductTemplateBrandFeature> ProductTemplateBrandFeatures { get; set; }
        
        public virtual ICollection<ProductGroupTemplateFeature> ProductGroupTemplateFeature { get; set; }

        public virtual ICollection<ProductGroup> ProductGroup { get; set; }

    }

}
