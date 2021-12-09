using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;

namespace Application.Model.Product
{
    public partial class Feature
    {
        public Feature()
        {
            FeatureValue = new HashSet<FeatureValue>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]
        public int Id { get; set; }


        [MaxLength(50)]
        [LookupDisplayAttribute]
        [FilterParam(startsWith = true, useInJoin = true)]
        [Required(ErrorMessage = "Feature Name is required")]
        public string FeatureName { get; set; }


        [Timestamp]
        public byte[] ts { get; set; }

        public virtual ICollection<FeatureValue> FeatureValue { get; set; }
    }

}
