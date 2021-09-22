using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Sale
    {
        public long SaleId { get; set; }
        public long? OperationId { get; set; }
        public long? InventoryId { get; set; }
        public decimal? Qty { get; set; }
        public decimal? NominalPrice { get; set; }
        public decimal? NominalPriceDiscount { get; set; }
        public decimal? SchemaPrice { get; set; }
        public decimal? SalesPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? VatRate { get; set; }
        public decimal? CogsPrice { get; set; }
        public decimal? Revenue { get; set; }
        public decimal? VatAmount { get; set; }
        public bool? UndefinedLocation { get; set; }
        public long? ParentSalesId { get; set; }
        public long? AccountBalanceId { get; set; }
        public byte[] AccountBalanceIdTimestamp { get; set; }
        public long? ValueTransactionId { get; set; }
        public long? QtyTransactionId { get; set; }
        public bool? StockFinPosted { get; set; }
        public bool? QtyPosted { get; set; }
        public bool? SalesFinPosted { get; set; }
        public int Posted { get; set; }

        public virtual Inventory Inventory { get; set; }
        public virtual Operation Operation { get; set; }
    }
}
