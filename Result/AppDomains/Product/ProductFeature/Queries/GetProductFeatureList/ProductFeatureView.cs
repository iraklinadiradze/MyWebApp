using System;
using System.Collections.Generic;
using System.Text;

using DataAccessLayer.Model.Product;


namespace Application.Domains.Product.ProductFeature.Queries.GetProductFeatureList
{
    public class ProductFeatureView: DataAccessLayer.Model.Product.ProductFeature
    {

          public class _FeatureValue
{
 public Int32 Id {get; set;} 
 public Int32 FeatureValueName {get; set;} 
}

public class _Product
{
 public Int32 Id {get; set;} 
 public String ProductName {get; set;} 
}

           public _FeatureValue featureValue {get; set;} 

 public _Product product {get; set;} 

    }
}
