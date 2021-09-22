using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Company2
    {
        public Company2()
        {
            Location1s = new HashSet<Location1>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<Location1> Location1s { get; set; }
    }
}
