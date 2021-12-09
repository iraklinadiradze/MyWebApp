using System;
using System.Collections.Generic;
using System.Text;

using Application.Model.Product;


namespace Application.Domains.Product.ProductGroup.Queries.GetProductGroupList
{
    public class ProductGroupView: Application.Model.Product.ProductGroup
    {

          public class _ProductCategory
{
 public Int32 Id {get; set;} 
}

public class _ProductGroupTemplate
{
 public Int32 Id {get; set;} 
 public String ProductGroupTemplateName {get; set;} 
}

           public _ProductCategory productCategory {get; set;} 

 public _ProductGroupTemplate productGroupTemplate {get; set;} 

    }
}
