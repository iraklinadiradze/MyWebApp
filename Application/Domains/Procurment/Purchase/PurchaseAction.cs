using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domains.Procurment.Purchase
{
    public enum PurchaseAction
    {
        paFullPost,

        paQtyPost,
        paCostPost,

        paFullUnpost,
        paFullUnpostWithDetails,

        paCostUnpost,
        paCostUnpostWithDetails,

        paQtyUnpost,
        paQtyUnpostWithDetails,

        paEodRepost
    }
}
