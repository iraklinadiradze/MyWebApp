using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;

using Application.Model.Core;
using System.ComponentModel;

namespace Application.Model.Inventory
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
        public long Id { get; set; }
        
        public DateTime? SendDate { get; set; }
        public DateTime? ReceiveDate { get; set; }

        public int SendLocationId { get; set; }

        public int ReceiveLocationId { get; set; }

        [DefaultValue("false")]
        public bool SendQtyPostStarted { get; set; }

        [DefaultValue("false")]
        public bool SendCostPostStarted { get; set; }

        [DefaultValue("false")]
        public bool ReceiveQtyPostStarted { get; set; }
        [DefaultValue("false")]
        public bool ReceiveFinPostStarted { get; set; }

        [DefaultValue("false")]
        public bool SendQtyPosted { get; set; }

        [DefaultValue("false")]
        public bool SendCostPosted { get; set; }

        [DefaultValue("false")]
        public bool ReceiveQtyPosted { get; set; }

        [DefaultValue("false")]
        public bool ReceiveCostPosted { get; set; }

        [DefaultValue("false")]
        public bool SendPosted { get; set; }

        [DefaultValue("false")]
        public bool ReceivePosted { get; set; }

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
