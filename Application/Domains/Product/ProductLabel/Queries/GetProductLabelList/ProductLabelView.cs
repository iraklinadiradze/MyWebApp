using System;
using System.Collections.Generic;
using System.Text;

using Application.Model.Product;


namespace Application.Domains.Product.ProductLabel.Queries.GetProductLabelList
{
    public class ProductLabelView: Application.Model.Product.ProductLabel
    {

          public class _Brand
{
 public Int32 Id {get; set;} 
 public String BrandName {get; set;} 
}

           public _Brand brand {get; set;} 

    }
}
