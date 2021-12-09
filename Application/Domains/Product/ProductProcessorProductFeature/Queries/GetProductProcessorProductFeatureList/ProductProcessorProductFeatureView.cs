using System;
using System.Collections.Generic;
using System.Text;

using Application.Model.Product;


namespace Application.Domains.Product.ProductProcessorProductFeature.Queries.GetProductProcessorProductFeatureList
{
    public class ProductProcessorProductFeatureView: Application.Model.Product.ProductProcessorProductFeature
    {

          public class _ProductProcessorDetail
{
 public Int32 Id {get; set;} 
}

           public _ProductProcessorDetail productProcessorDetail {get; set;} 

    }
}
