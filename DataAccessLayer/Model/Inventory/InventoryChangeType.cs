using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLib.Attributes;

namespace DataAccessLayer.Model.Inventory
{
    public class InventoryChangeType
    {
        public InventoryChangeType()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]
        public int Id { get; set; }

        [MaxLength(30)]
        [LookupDisplayAttribute]
        [FilterParam(startsWith = true, useInJoin = true)]
        [Required(ErrorMessage = "Change Name is required")]
        public string ChangeName { get; set; }

        [FilterParam(useInJoin = true)]
        [Required(ErrorMessage = "Change Code is required")]
        public string ChangeCode { get; set; }

        public bool IsQtyRelated { get; set; }

        public bool IsFinRelated { get; set; }

    }

}
