using System;
using System.Collections.Generic;
using System.Text;

using Application.Model.Inventory;


namespace Application.Domains.Inventory.MovementDetail.Queries.GetMovementDetailList
{
    public class MovementDetailView : Application.Model.Inventory.MovementDetail
    {

        public class _Inventory
        {
            public long Id { get; set; }
            public String InventoryCode { get; set; }
        }

        public class _Movement
        {
            public long Id { get; set; }
        }

        public _Inventory inventory { get; set; }

        public _Movement movement { get; set; }

    }
}
