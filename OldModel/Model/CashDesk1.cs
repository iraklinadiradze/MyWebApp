using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class CashDesk1
    {
        public int CashDeskId { get; set; }
        public string CashDeskCode { get; set; }
        public int LocationId { get; set; }
        public string Descrip { get; set; }

        public virtual Location1 Location { get; set; }
    }
}
