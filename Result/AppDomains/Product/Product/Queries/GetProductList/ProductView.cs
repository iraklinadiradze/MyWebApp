using System;
using System.Collections.Generic;
using System.Text;

using DataAccessLayer.Model.Product;


namespace Application.Domains.Product.Product.Queries.GetProductList
{
    public class ProductView: DataAccessLayer.Model.Product.Product
    {

          public class _ProductGroup
{
 public Int32 Id {get; set;} 
}

public class _ProductLabel
{
 public Int32 Id {get; set;} 
 public String ProductLabelName {get; set;} 
}

public class _ProductUnit
{
 public Int32 Id {get; set;} 
 public String ProductUnitName {get; set;} 
}

           public _ProductGroup productGroup {get; set;} 

 public _ProductLabel productLabel {get; set;} 

 public _ProductUnit productUnit {get; set;} 

    }
}
