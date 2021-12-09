using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;

namespace Application.Model.Client
{
    public partial class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals=true, useInJoin = true)]
        public int Id { get; set; }

        public bool? IsPerson { get; set; }

        [MaxLength(50)]
        [FilterParam(startsWith = true, useInJoin = true)]
//        [Required(ErrorMessage = "Last Name is required")]
        public string Name { get; set; }

        public bool? IsSupplier { get; set; }
        public bool? IsCustomer { get; set; }
        public bool? IsBank { get; set; }
        public bool? IsEmployee{ get; set; }

        public virtual Person Person { get; set; }
        public virtual LegalEntity LegalEntity { get; set; }
    }

}
