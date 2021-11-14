using System;
using System.Collections.Generic;
using System.Text;

using DataAccessLayer.Model.Procurment;


namespace Application.Domains.Procurment.PurchaseAllocationResult.Queries.GetPurchaseAllocationResultList
{
    public class PurchaseAllocationResultView: DataAccessLayer.Model.Procurment.PurchaseAllocationResult
    {

          public class _PurchaseAllocationSource
{
 public Int32 Id {get; set;} 
}

public class _PurchaseDetail
{
 public Int32 Id {get; set;} 
}

           public _PurchaseAllocationSource purchaseAllocationSource {get; set;} 

 public _PurchaseDetail purchaseDetail {get; set;} 

    }
}
