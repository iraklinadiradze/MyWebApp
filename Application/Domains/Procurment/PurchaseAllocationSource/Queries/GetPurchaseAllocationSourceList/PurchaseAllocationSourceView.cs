using System;
using System.Collections.Generic;
using System.Text;

using Application.Model.Procurment;


namespace Application.Domains.Procurment.PurchaseAllocationSource.Queries.GetPurchaseAllocationSourceList
{
    public class PurchaseAllocationSourceView : Application.Model.Procurment.PurchaseAllocationSource
    {

        public class _Purchase
        {
            public long Id { get; set; }
        }

        public class _PurchaseAllocationSchema
        {
            public Int32 Id { get; set; }
        }

        public class _PurchaseAllocationSourceType
        {
            public Int32 Id { get; set; }
        }

        public class _PurchaseDetail
        {
            public long Id { get; set; }
        }

        public _Purchase purchase { get; set; }

        public _PurchaseAllocationSchema purchaseAllocationSchema { get; set; }

        public _PurchaseAllocationSourceType purchaseAllocationSourceType { get; set; }

        public _PurchaseDetail purchaseDetail { get; set; }

    }
}
