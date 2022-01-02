using System;
using System.Collections.Generic;
using System.Text;

using Application.Model.Procurment;


namespace Application.Domains.Procurment.PurchaseAllocationResult.Queries.GetPurchaseAllocationResultList
{
    public class PurchaseAllocationResultView : Application.Model.Procurment.PurchaseAllocationResult
    {

        public class _PurchaseAllocationSource
        {
            public Int32 Id { get; set; }
        }

        public class _PurchaseDetail
        {
            public long Id { get; set; }
        }

        public _PurchaseAllocationSource purchaseAllocationSource { get; set; }

        public _PurchaseDetail purchaseDetail { get; set; }

    }
}
