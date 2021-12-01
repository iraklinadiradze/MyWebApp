using System;
using System.Collections.Generic;
using System.Text;

using DataAccessLayer.Model.Inventory;


namespace Application.Domains.Inventory.InventoryChange.Queries.GetInventoryChangeList
{
    public class InventoryChangeView: DataAccessLayer.Model.Inventory.InventoryChange
    {

          public class _Inventory
{
 public long Id {get; set;} 
 public String InventoryCode {get; set;} 
}

public class _InventoryChangeType
{
 public Int32 Id {get; set;} 
 public String ChangeCode {get; set;} 
 public String ChangeName {get; set;} 
}

           public _Inventory inventory {get; set;} 

 public _InventoryChangeType inventoryChangeType {get; set;} 

    }
}
