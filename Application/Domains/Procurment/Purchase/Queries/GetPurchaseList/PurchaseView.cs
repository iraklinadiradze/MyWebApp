using System;
using System.Collections.Generic;
using System.Text;

using DataAccessLayer.Model.Procurment;


namespace Application.Domains.Procurment.Purchase.Queries.GetPurchaseList
{
    public class PurchaseView: DataAccessLayer.Model.Procurment.Purchase
    {

          public class _Client
{
 public Int32 Id {get; set;} 
 public String Name {get; set;} 
}

public class _Currency
{
 public Int32 Id {get; set;} 
 public String CurrencyCode {get; set;} 
}

           public _Client client {get; set;} 

 public _Currency currency {get; set;} 

    }
}
