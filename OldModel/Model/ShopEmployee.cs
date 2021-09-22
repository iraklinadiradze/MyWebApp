using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ShopEmployee
    {
        public int ShopEmpoyeeId { get; set; }
        public int? ShopId { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Location1 Shop { get; set; }
    }
}
