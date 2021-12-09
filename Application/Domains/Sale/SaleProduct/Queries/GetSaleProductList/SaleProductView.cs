using System;
using System.Collections.Generic;
using System.Text;

using Application.Model.Sale;


namespace Application.Domains.Sale.SaleProduct.Queries.GetSaleProductList
{
    public class SaleProductView: Application.Model.Sale.SaleProduct
    {

          public class _Sale
{
 public Int32 Id {get; set;} 
}

           public _Sale sale {get; set;} 

    }
}
