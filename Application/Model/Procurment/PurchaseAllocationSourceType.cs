using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;

using Application.Model.Client;
using Application.Model.Core;
using Application.Model.Product;
using Application.Model.Inventory;

namespace Application.Model.Procurment
{
    public class PurchaseAllocationSourceType
    {

        public PurchaseAllocationSourceType()
        {
        }

        [Key]
//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]
        public int Id { get; set; }

        public string Name{ get; set; }

        //       public bool PostStarted { get; set; }
        //        public bool Posted { get; set; }

    }
}
