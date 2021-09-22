using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLib.Attributes;

namespace DataAccessLayer.Model.Product
{
    public partial class ProductCategory
    {

        public ProductCategory()
        {
            ProductGroup = new HashSet<ProductGroup>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]
        public int Id { get; set; }

        [FilterParam(equals = true)]
        [MaxLength(50)]
        public string ProductCategoryName { get; set; }

        public virtual ICollection<ProductGroup> ProductGroup { get; set; }

    }

}
