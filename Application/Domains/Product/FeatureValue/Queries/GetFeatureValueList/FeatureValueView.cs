using System;
using System.Collections.Generic;
using System.Text;

using DataAccessLayer.Model.Product;


namespace Application.Domains.Product.FeatureValue.Queries.GetFeatureValueList
{
    public class FeatureValueView: DataAccessLayer.Model.Product.FeatureValue
    {

          public class _Feature
{
 public Int32 Id {get; set;} 
 public String FeatureName {get; set;} 
}

           public _Feature feature {get; set;} 

    }
}
