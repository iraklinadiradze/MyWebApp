using System;
using System.Collections.Generic;
using System.Text;

using Application.Model.Sale;


namespace Application.Domains.Sale.SalePayment.Queries.GetSalePaymentList
{
    public class SalePaymentView: Application.Model.Sale.SalePayment
    {

          public class _Sale
{
 public Int32 Id {get; set;} 
}

public class _SalePaymentType
{
 public Int32 Id {get; set;} 
}

           public _Sale sale {get; set;} 

 public _SalePaymentType salePaymentType {get; set;} 

    }
}
