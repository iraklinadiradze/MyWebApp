using System;
using System.Collections.Generic;
using System.Text;

using DataAccessLayer.Model.Inventory;


namespace Application.Domains.Inventory.Inventory.Queries.GetInventoryList
{
    public class InventoryView: DataAccessLayer.Model.Inventory.Inventory
    {

          public class _Product
{
 public Int32 Id {get; set;} 
 public String ProductName {get; set;} 
}

public class _ProductUnit
{
 public Int32 Id {get; set;} 
 public String ProductUnitName {get; set;} 
}

           public _Product product {get; set;} 

 public _ProductUnit productUnit {get; set;} 

    }
}
