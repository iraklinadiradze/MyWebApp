using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;

namespace Application.Model.Product
{
    public partial class Brand
    {
        public Brand()
        {
          ProductLabel = new HashSet<ProductLabel>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]
        public int Id { get; set; }

        [MaxLength(50)]
        [LookupDisplayAttribute]
        [FilterParam(startsWith = true, useInJoin = true)]
        [Required(ErrorMessage = "Brand Name is required")]
        public string BrandName { get; set; }

        public virtual ICollection<ProductLabel> ProductLabel { get; set; }

    }
}
