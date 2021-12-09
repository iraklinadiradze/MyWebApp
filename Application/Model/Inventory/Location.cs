using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;


namespace Application.Model.Inventory
{
    public class Location
    {
        public Location()
        {
            //            Person = new HashSet<Person>();
            //            LegalEntity = new HashSet<LegalEntity>();
            //  Client = new HashSet<Client>();
          //  SendMovement = new HashSet<Movement>();
          //  ReceiveMovement = new HashSet<Movement>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]
        public int Id { get; set; }

        [MaxLength(30)]
        [LookupDisplayAttribute]
        [FilterParam(startsWith = true, useInJoin = true)]
        [Required(ErrorMessage = "Location Name is required")]
        public string Name { get; set; }

//        public virtual ICollection<Movement> SendMovement { get; set; }
 //       public virtual ICollection<Movement> ReceiveMovement { get; set; }


    }
}
