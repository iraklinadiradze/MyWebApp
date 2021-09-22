using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLib.Attributes;

using DataAccessLayer.Model.Core;

namespace DataAccessLayer.Model.Inventory
{
    public partial class Movement
    {
        public Movement()
        {
            MovementDetail = new HashSet<MovementDetail>();

            //            PurchaseDetails = new HashSet<PurchaseDetail>();
            //            Sales = new HashSet<Sale>();s
            //            StockCountDetails = new HashSet<StockCountDetail>();
            //            StockWriteoffDetails = new HashSet<StockWriteoffDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [FilterParam(equals = true, useInJoin = true)]
        public int Id { get; set; }
        
        public DateTime? SendDate { get; set; }
        public DateTime? ReceiveDate { get; set; }

        public int SendLocationId { get; set; }

        public int ReceiveLocationId { get; set; }

        public bool? SendQtyPostStarted { get; set; }
        public bool? SendFinPostStarted { get; set; }

        public bool? ReceiveQtyPostStarted { get; set; }
        public bool? ReceiveFinPostStarted { get; set; }

        public bool? SendQtyPosted { get; set; }
        public bool? SendFinPosted { get; set; }

        public bool? ReceiveQtyPosted { get; set; }
        public bool? ReceiveFinPosted { get; set; }

        public bool? SendPosted { get; set; }
        public bool? ReceivePosted { get; set; }

        public virtual ICollection<MovementDetail> MovementDetail{ get; set; }

        [ForeignKey("SendLocationId")]
        public virtual Location SendLocation { get; set; }

        [ForeignKey("ReceiveLocationId")]
        public virtual Location ReceiveLocation { get; set; }

        //        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
        //        public virtual ICollection<Sale> Sales { get; set; }
        //        public virtual ICollection<StockCountDetail> StockCountDetails { get; set; }
        //        public virtual ICollection<StockWriteoffDetail> StockWriteoffDetails { get; set; }
    }

}
