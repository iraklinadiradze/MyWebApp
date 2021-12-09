using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;

namespace Application.Model.Product
{
    public class ProductGroup
    {
        public ProductGroup()
        {
           Product = new HashSet<Product>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]
        public int Id { get; set; }

        [FilterParam(equals = true)]
        [MaxLength(50)]
        public string ProductGroupName { get; set; }


        [FilterParam(equals = true)]
        [ForeignKey("ProductCategory")]
        public int ProductCategoryId { get; set; }

        [FilterParam(equals = true)]
        [ForeignKey("ProductGroupTemplate")]
        public int ProductGroupTemplateId { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ProductGroupTemplate ProductGroupTemplate { get; set; }

        public virtual ICollection<Product> Product { get; set; }

    }
}
