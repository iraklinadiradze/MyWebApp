using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLib.Attributes;

namespace DataAccessLayer.Model.Product
{
    public partial class ProductFeature
    {
        public int Id { get; set; }

        [FilterParam(equals = true)]
        [ForeignKey("Product")]
        [Required(ErrorMessage = "Product Id is required")]
        public int ProductId { get; set; }

        [FilterParam(equals = true)]
        [ForeignKey("FeatureValue")]
        [Required(ErrorMessage = "Feature Value Id is required")]
        public int FeatureValueId { get; set; }

        public virtual FeatureValue FeatureValue { get; set; }
        public virtual Product Product { get; set; }
    }

}
