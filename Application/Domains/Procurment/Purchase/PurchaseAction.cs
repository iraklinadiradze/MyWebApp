using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domains.Procurment.Purchase
{
    public enum PurchaseAction
    {
        paFullPost,

        paQtyPost,
        paFinPost,

        paFullUnpost,
        paFullUnpostWithDetails,

        paFinUnpost,
        paFinUnpostWithDetails,

        paQtyUnpost,
        paQtyUnpostWithDetails,

        paEodRepost
    }
}
