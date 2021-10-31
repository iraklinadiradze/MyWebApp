using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLib.Attributes;

using DataAccessLayer.Model.Client;
using DataAccessLayer.Model.Core;
using DataAccessLayer.Model.Product;
using DataAccessLayer.Model.Inventory;

namespace DataAccessLayer.Model.Procurment
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
