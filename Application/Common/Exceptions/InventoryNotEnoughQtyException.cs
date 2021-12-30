using Application.Model.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Exceptions
{
    public class InventoryNotEnoughQtyException : Exception
    {
        public string InventoryCode { get; }
        public long InventoryId { get; }
        public long Locationid { get; }
        public DateTime TransDate { get; }


        public InventoryNotEnoughQtyException(Inventory inventory, long locationid, DateTime transDate)
            : base("Cna not make Action, Not Enough Inventory")
        {
            InventoryCode = inventory.InventoryCode;
            InventoryId = inventory.Id;
            Locationid = locationid;
            TransDate = transDate;
        }

    }
}
