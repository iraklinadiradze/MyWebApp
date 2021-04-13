using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLib.Attributes;

namespace DataAccessLayer
{
    public partial class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [MaxLength(11)]
        [FilterParam(equals=true, useInJoin = true)]
        [Required(ErrorMessage = "PersonalId Name is required")]
        public string PersonalId { get; set; }

        [FilterParam(equals = true)]
        public int? ClientTypeId { get; set; }

        [FilterParam(range = true)]
        public DateTime? BirthDate { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(20)]
        public string Mobile { get; set; }

        [MaxLength(45)]
        public string Email { get; set; }

        [ForeignKey("Id")]
        public virtual ClientType ClientType { get; set; }
    }

}
