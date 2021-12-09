using System;
using System.Collections.Generic;
using System.Text;

using Application.Model.Procurment;


namespace Application.Domains.Procurment.PurchaseDetail.Queries.GetPurchaseDetailList
{
    public class PurchaseDetailView : Application.Model.Procurment.PurchaseDetail
    {

        public class _Inventory
        {
            public long Id { get; set; }
            public String InventoryCode { get; set; }
        }

        public class _Location
        {
            public Int32 Id { get; set; }
            public String Name { get; set; }
        }

        public class _Purchase
        {
            public Int32 Id { get; set; }
        }

        public class _PurchaseDetailPostType
        {
            public Int32 Id { get; set; }
        }

        public class _Product
        {
            public Int32 Id { get; set; }
            public String ProductName { get; set; }
        }

        public _Inventory inventory { get; set; }

        public _Location location { get; set; }

        public _Purchase purchase { get; set; }

        public _PurchaseDetailPostType purchaseDetailPostType { get; set; }

        public _Product product { get; set; }

    }
}
