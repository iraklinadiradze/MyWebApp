using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLib.Attributes;

namespace DataAccessLayer.Model.Product
{
    public partial class ProductUnit
    {
        public ProductUnit()
        {
            Product = new HashSet<Product>();
            ProductGroupTemplate = new HashSet<ProductGroupTemplate>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]
        public int Id { get; set; }

        [MaxLength(50)]
        [LookupDisplayAttribute]
        [FilterParam(startsWith = true, useInJoin = true)]
        public string ProductUnitName { get; set; }

        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<ProductGroupTemplate> ProductGroupTemplate { get; set; }

    }
}
