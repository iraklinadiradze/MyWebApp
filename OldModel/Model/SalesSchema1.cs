using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class SalesSchema1
    {
        public SalesSchema1()
        {
            Location1s = new HashSet<Location1>();
            SalesSchemaDetails = new HashSet<SalesSchemaDetail>();
        }

        public int SalesSchemaId { get; set; }
        public string SalesSchemaName { get; set; }

        public virtual ICollection<Location1> Location1s { get; set; }
        public virtual ICollection<SalesSchemaDetail> SalesSchemaDetails { get; set; }
    }
}
