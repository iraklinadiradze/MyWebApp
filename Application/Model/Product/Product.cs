using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;

namespace Application.Model.Product
{
    public partial class Product
    {
        public Product()
        {
            ProductFeature = new HashSet<ProductFeature>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]
        public int Id { get; set; }

        [MaxLength(50)]
        [LookupDisplayAttribute]
        [FilterParam(startsWith = true, useInJoin = true)]
        public string ProductName { get; set; }
        
        [FilterParam(equals = true)]
        [ForeignKey("ProductGroup")]
        public int ProductGroupId { get; set; }

        [FilterParam(equals = true)]
        [MaxLength(30)]
        public string ProductCode { get; set; }

        public bool? IsTangible { get; set; }

        public bool? IsSingle { get; set; }

        public bool? IsWholeQuantity { get; set; }

        [FilterParam(equals = true)]
        [ForeignKey("ProductUnit")]
        public int ProductUnitId { get; set; }

        [FilterParam(equals = true)]
        [ForeignKey("ProductLabel")]
        public int ProductLabelId { get; set; }

        public virtual ProductGroup ProductGroup { get; set; }
        public virtual ProductUnit ProductUnit { get; set; }
        public virtual ProductLabel ProductLabel { get; set; }
        
        public virtual ICollection<ProductFeature> ProductFeature { get; set; }
    }

}
