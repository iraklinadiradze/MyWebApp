using System;
using System.Collections.Generic;
using System.Text;

using DataAccessLayer.Model.Sale;


namespace Application.Domains.Sale.ReturnProduct.Queries.GetReturnProductList
{
    public class ReturnProductView: DataAccessLayer.Model.Sale.ReturnProduct
    {

          public class _Sale
{
 public Int32 Id {get; set;} 
}

           public _Sale sale {get; set;} 

    }
}
