using System;
using System.Collections.Generic;
using System.Text;

using Application.Model.Product;


namespace Application.Domains.Product.ProductFeature.Queries.GetProductFeatureList
{
    public class ProductFeatureView: Application.Model.Product.ProductFeature
    {

          public class _FeatureValue
{
 public Int32 Id {get; set;} 
 public String FeatureValueName {get; set;} 
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
