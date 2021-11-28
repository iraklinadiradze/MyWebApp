using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domains.Inventory.InventoryChangeType.Common
{
    public enum InventoryChangeTypeEnum
    {
        ictPurchase = 0,
        ictMovement = 1,
        ictTransformation = 2,
        ictWriteOff = 3,
        ictSale = 4
    }

}
