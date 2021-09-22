using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Shelf
    {
        public int ShelfId { get; set; }
        public int? LocationId { get; set; }
        public string ShelfCode { get; set; }
        public string ShelfDescription { get; set; }

        public virtual Location1 Location { get; set; }
    }
}
