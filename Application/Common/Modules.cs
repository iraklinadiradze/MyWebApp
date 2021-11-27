using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common
{
    public enum ModuleEnum
    {
        mdUndefined = 0,
        mdAccount ,
        mdClient ,
        mdCore ,
        mdGeneralLedger,
        mdInventory,
        mdPurchase,
        mdPurchaseDetail,
        mdProduct,
        mdSale
    }
}
