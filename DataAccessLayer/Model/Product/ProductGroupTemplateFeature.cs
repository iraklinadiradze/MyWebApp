using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLib.Attributes;

namespace DataAccessLayer.Model.Product
{
    public partial class ProductGroupTemplateFeature
    {
        public ProductGroupTemplateFeature()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]
        public int Id { get; set; }


        [FilterParam(equals = true)]
        [ForeignKey("ProductGroupTemplate")]
        [Required(ErrorMessage = "Product Group Template Id is required")]
        public int ProductGroupTemplateId { get; set; }

        [FilterParam(equals = true)]
        [ForeignKey("Feature")]
        [Required(ErrorMessage = "Feature is required")]
        public int FeatureId { get; set; }

        public bool? IsMandatory { get; set; }
      
        public virtual ProductGroupTemplate ProductGroupTemplate { get; set; }

        public virtual Feature Feature { get; set; }

    }

}
