using System;
using System.Collections.Generic;
using System.Text;

using DataAccessLayer.Model.Sale;


namespace Application.Domains.Sale.SaleProduct.Queries.GetSaleProductList
{
    public class SaleProductView: DataAccessLayer.Model.Sale.SaleProduct
    {

          public class _Sale
{
 public Int32 Id {get; set;} 
}

           public _Sale sale {get; set;} 

    }
}
