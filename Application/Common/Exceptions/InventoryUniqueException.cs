using Application.Model.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Exceptions
{
    public class InventoryUniqueException : Exception
    {
        public string InventoryCode { get; }
        public long Inventory_id { get; }
        public long? RelatedEntityForeignId { get; }
        public int? RelatedEntityId { get; }

        public InventoryUniqueException(string inventoryCode, Inventory inventory)
            : base("Inventory With Code Already Exists")
        {
            InventoryCode = inventoryCode;
            Inventory_id = inventory.Id;
            RelatedEntityForeignId = inventory.EntityForeignId;
            RelatedEntityId = inventory.EntityId;
        }

    }
}
