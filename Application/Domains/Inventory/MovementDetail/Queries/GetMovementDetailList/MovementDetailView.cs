using System;
using System.Collections.Generic;
using System.Text;

using DataAccessLayer.Model.Inventory;


namespace Application.Domains.Inventory.MovementDetail.Queries.GetMovementDetailList
{
    public class MovementDetailView: DataAccessLayer.Model.Inventory.MovementDetail
    {

          public class _Inventory
{
 public Int32 Id {get; set;} 
 public String InventoryCode {get; set;} 
}

public class _Movement
{
 public Int32 Id {get; set;} 
}

           public _Inventory inventory {get; set;} 

 public _Movement movement {get; set;} 

    }
}
