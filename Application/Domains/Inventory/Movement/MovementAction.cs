using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domains.Inventory.Movement
{
    public enum MovementAction
    {
        maFullPost,

        maQtyPost,
        maCostPost,

        maFullUnpost,
        maFullUnpostWithDetails,

        maCostUnpost,
        maCostUnpostWithDetails,

        maQtyUnpost,
        maQtyUnpostWithDetails,

        maEodRepost
    }

}
