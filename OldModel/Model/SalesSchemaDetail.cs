using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class SalesSchemaDetail
    {
        public int SalesSchemaDetailId { get; set; }
        public int SalesSchemaId { get; set; }
        public long? ProductId { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal? UnitPriceAd { get; set; }
        public DateTime? ChangeDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual SalesSchema1 SalesSchema { get; set; }
    }
}
