using System;
using System.Collections.Generic;
using System.Text;

using Application.Model.Product;


namespace Application.Domains.Product.ProductProcessorSalePrice.Queries.GetProductProcessorSalePriceList
{
    public class ProductProcessorSalePriceView: Application.Model.Product.ProductProcessorSalePrice
    {

          public class _ProductProcessorDetail
{
 public Int32 Id {get; set;} 
}

           public _ProductProcessorDetail productProcessorDetail {get; set;} 

    }
}
