using System;
using System.Collections.Generic;
using System.Text;

using DataAccessLayer.Model.Product;


namespace Application.Domains.Product.ProductProcessorDetail.Queries.GetProductProcessorDetailList
{
    public class ProductProcessorDetailView: DataAccessLayer.Model.Product.ProductProcessorDetail
    {

          public class _ProductProcessor
{
 public Int32 Id {get; set;} 
}

           public _ProductProcessor productProcessor {get; set;} 

    }
}
