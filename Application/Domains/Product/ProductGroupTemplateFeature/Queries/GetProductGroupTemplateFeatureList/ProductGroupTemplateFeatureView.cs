using System;
using System.Collections.Generic;
using System.Text;

using Application.Model.Product;


namespace Application.Domains.Product.ProductGroupTemplateFeature.Queries.GetProductGroupTemplateFeatureList
{
    public class ProductGroupTemplateFeatureView: Application.Model.Product.ProductGroupTemplateFeature
    {

          public class _Feature
{
 public Int32 Id {get; set;} 
 public String FeatureName {get; set;} 
}

public class _ProductGroupTemplate
{
 public Int32 Id {get; set;} 
 public String ProductGroupTemplateName {get; set;} 
}

           public _Feature feature {get; set;} 

 public _ProductGroupTemplate productGroupTemplate {get; set;} 

    }
}
