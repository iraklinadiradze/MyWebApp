using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;
using Application.Model.Client;

namespace Application.Model.Core
{
    public partial class Country
    {
        public Country()
        {
//            Person = new HashSet<Person>();
//            LegalEntity = new HashSet<LegalEntity>();
          //  Client = new HashSet<Client>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals=true, useInJoin = true)]
        public int Id { get; set; }

        [MaxLength(30)]
        [LookupDisplayAttribute]
        [FilterParam(startsWith = true, useInJoin = true)]
        [Required(ErrorMessage = "Country Name is required")]
        public string Name { get; set; }

        [MaxLength(3)]
        [FilterParam(equals=true, useInJoin = true)]
        [Required(ErrorMessage = "Code is required")]
        public string Code{ get; set; }

//        public virtual Person Person { get; set; }
//        public virtual LegalEntity LegalEntity { get; set; }

        public virtual ICollection<Person> Person { get; set; }
        public virtual ICollection<LegalEntity> LegalEntity { get; set; }
        //  public virtual ICollection<Client> Client { get; set; }

    }

}
