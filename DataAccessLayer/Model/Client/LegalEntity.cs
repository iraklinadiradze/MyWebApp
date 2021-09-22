using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLib.Attributes;
using DataAccessLayer.Model.Core;

namespace DataAccessLayer.Model.Client
{
    public partial class LegalEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("Client")]
        [FilterParam(equals=true, useInJoin = true)]
        public int Id { get; set; }

        [MaxLength(100)]
        [FilterParam(startsWith = true, useInJoin = true)]
        [Required(ErrorMessage = "Legal Entity Name is required")]
        public string LegalEntityName { get; set; }

        [FilterParam(equals = true)]
        [ForeignKey("Country")]
        public int RegistrationCountryID { get; set; }

        [MaxLength(11)]
        [FilterParam(equals=true, useInJoin = true)]
        [Required(ErrorMessage = "TaxCode is required")]
        public string TaxCode { get; set; }

        public DateTime? TaxRegDate { get; set; }

        public string LegalAddress { get; set; }

        [MaxLength(200)]
        public string OfficeAddress { get; set; }

        [MaxLength(20)]
        public string Mobile { get; set; }

        [MaxLength(45)]
        public string Email { get; set; }

        public virtual Client Client { get; set; }
        public virtual Country Country { get; set; }

    }

}
