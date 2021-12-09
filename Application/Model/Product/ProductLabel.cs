using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;

namespace Application.Model.Product
{
    public partial class ProductLabel
    {
        public ProductLabel()
        {
            Product = new HashSet<Product>();
        }   

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]
        public int Id { get; set; }

        [FilterParam(equals = true)]
        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        [MaxLength(50)]
        [LookupDisplayAttribute]
        [FilterParam(startsWith = true, useInJoin = true)]
        public string ProductLabelName { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual ICollection<Product> Product { get; set; }

    }

}
