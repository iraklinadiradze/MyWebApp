using System;
using System.Collections.Generic;
using System.Text;

using Application.Model.Sale;


namespace Application.Domains.Sale.SaleSchemaDetail.Queries.GetSaleSchemaDetailList
{
    public class SaleSchemaDetailView: Application.Model.Sale.SaleSchemaDetail
    {

          public class _Product
{
 public Int32 Id {get; set;} 
 public String ProductName {get; set;} 
}

public class _SaleSchema
{
 public Int32 Id {get; set;} 
}

           public _Product product {get; set;} 

 public _SaleSchema saleSchema {get; set;} 

    }
}
