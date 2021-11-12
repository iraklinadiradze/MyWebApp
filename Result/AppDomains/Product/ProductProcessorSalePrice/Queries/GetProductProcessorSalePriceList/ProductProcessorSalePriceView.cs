using System;
using System.Collections.Generic;
using System.Text;

using DataAccessLayer.Model.Product;


namespace Application.Domains.Product.ProductProcessorSalePrice.Queries.GetProductProcessorSalePriceList
{
    public class ProductProcessorSalePriceView: DataAccessLayer.Model.Product.ProductProcessorSalePrice
    {

          public class _ProductProcessorDetail
{
 public Int32 Id {get; set;} 
}

           public _ProductProcessorDetail productProcessorDetail {get; set;} 

    }
}
