using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;

namespace Application.Model
{
    class Company
    {
        public Company()
        {
            //            Person = new HashSet<Person>();
            //            LegalEntity = new HashSet<LegalEntity>();
            //  Client = new HashSet<Client>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]
        public int Id { get; set; }

        [MaxLength(30)]
        [LookupDisplayAttribute]
        [FilterParam(startsWith = true, useInJoin = true)]
        [Required(ErrorMessage = "Company Name is required")]
        public string Name { get; set; }

    }
}
