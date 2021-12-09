using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;

namespace Application.Model.Product
{
    public partial class FeatureValue
    {
        public FeatureValue()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]
        public int Id { get; set; }

        [FilterParam(equals = true)]
        [ForeignKey("Feature")]
        [Required(ErrorMessage = "Feature Id is required")]
        public int FeatureId { get; set; }

        [MaxLength(50)]
        [LookupDisplayAttribute]
        [FilterParam(startsWith = true, useInJoin = true)]
        public string FeatureValueName { get; set; }

        public virtual Feature Feature { get; set; }

    }

}
