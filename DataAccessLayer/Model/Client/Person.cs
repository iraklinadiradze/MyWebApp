using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLib.Attributes;

using DataAccessLayer.Model.Core;

namespace DataAccessLayer.Model.Client
{
    public partial class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("Client")]
        [FilterParam(equals=true, useInJoin = true)]
        public int Id { get; set; }

        [MaxLength(30)]
        [FilterParam(startsWith = true, useInJoin = true)]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [MaxLength(30)]
        [FilterParam(startsWith = true, useInJoin = true)]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [FilterParam(equals = true)]
        [ForeignKey("Country")]
        public int CitizenShipId { get; set; }

        [MaxLength(11)]
        [FilterParam(equals=true, useInJoin = true)]
        [Required(ErrorMessage = "PersonalId Name is required")]
        public string PersonalId { get; set; }

        [FilterParam(range = true)]
        public DateTime? BirthDate { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(20)]
        public string Mobile { get; set; }

        [MaxLength(45)]
        public string Email { get; set; }

        public virtual Client Client { get; set; }
        public virtual Country Country { get; set; }
    }

}
