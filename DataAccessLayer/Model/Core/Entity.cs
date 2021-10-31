using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLib.Attributes;

namespace DataAccessLayer.Model.Core
{
    public class Entity
    {
        [Key]
//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]
        public int Id { get; set; }
        public string EntityName{ get; set; }
        public string EntityCode { get; set; }
        public string EntityDescription { get; set; }

    }
}
