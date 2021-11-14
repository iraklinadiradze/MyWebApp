using System;
using System.Collections.Generic;
using System.Text;

using DataAccessLayer.Model.Product;


namespace Application.Domains.Product.ProductProcessorProductFeature.Queries.GetProductProcessorProductFeatureList
{
    public class ProductProcessorProductFeatureView: DataAccessLayer.Model.Product.ProductProcessorProductFeature
    {

          public class _ProductProcessorDetail
{
 public Int32 Id {get; set;} 
}

           public _ProductProcessorDetail productProcessorDetail {get; set;} 

    }
}
