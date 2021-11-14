using System;
using System.Collections.Generic;
using System.Text;

using DataAccessLayer.Model.Procurment;


namespace Application.Domains.Procurment.PurchaseAllocationSource.Queries.GetPurchaseAllocationSourceList
{
    public class PurchaseAllocationSourceView: DataAccessLayer.Model.Procurment.PurchaseAllocationSource
    {

          public class _Purchase
{
 public Int32 Id {get; set;} 
}

public class _PurchaseAllocationSchema
{
 public Int32 Id {get; set;} 
}

public class _PurchaseAllocationSourceType
{
 public Int32 Id {get; set;} 
}

public class _PurchaseDetail
{
 public Int32 Id {get; set;} 
}

           public _Purchase purchase {get; set;} 

 public _PurchaseAllocationSchema purchaseAllocationSchema {get; set;} 

 public _PurchaseAllocationSourceType purchaseAllocationSourceType {get; set;} 

 public _PurchaseDetail purchaseDetail {get; set;} 

    }
}
