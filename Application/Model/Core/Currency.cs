using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;


namespace Application.Model.Core
{
    public class Currency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]        
        public int Id { get; set; }

        [MaxLength(3)]
        [FilterParam(equals = true, useInJoin = true)]
        public string CurrencyCode { get; set; }

        [MaxLength(50)]
        public string CurrencyDescrip { get; set; }

    }
}
