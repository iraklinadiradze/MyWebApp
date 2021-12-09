using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;

namespace Application.Model.Product
{
    public partial class ProductProcessorSalePrice
    {
        public ProductProcessorSalePrice()
        {
//            ProductFeature = new HashSet<ProductFeature>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]
        public int Id { get; set; }

        [ForeignKey("ProductProcessorDetail")]
        public int ProductProcessorDetailId { get; set; }

        public int SaleSchemaId { get; set; }

        public decimal SalePrice{ get; set; }

        public virtual ProductProcessorDetail ProductProcessorDetail { get; set; }

    }

}
