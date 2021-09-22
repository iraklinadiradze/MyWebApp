using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Location1
    {
        public Location1()
        {
            CashDesk1s = new HashSet<CashDesk1>();
            Operations = new HashSet<Operation>();
            Shelves = new HashSet<Shelf>();
            ShopEmployees = new HashSet<ShopEmployee>();
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int? CompanyId { get; set; }
        public bool? IsShop { get; set; }
        public bool? IsWarehouse { get; set; }
        public string Address { get; set; }
        public int? SalesSchemaId { get; set; }

        public virtual Company2 Company { get; set; }
        public virtual SalesSchema1 SalesSchema { get; set; }
        public virtual ICollection<CashDesk1> CashDesk1s { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
        public virtual ICollection<Shelf> Shelves { get; set; }
        public virtual ICollection<ShopEmployee> ShopEmployees { get; set; }
    }
}
