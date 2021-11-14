using System;
using System.Collections.Generic;
using System.Text;

using DataAccessLayer.Model.Product;


namespace Application.Domains.Product.ProductGroupTemplate.Queries.GetProductGroupTemplateList
{
    public class ProductGroupTemplateView: DataAccessLayer.Model.Product.ProductGroupTemplate
    {

          public class _ProductUnit
{
 public Int32 Id {get; set;} 
 public String ProductUnitName {get; set;} 
}

           public _ProductUnit productUnit {get; set;} 

    }
}
